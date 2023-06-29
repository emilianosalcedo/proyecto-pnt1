using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Context;
using Peluqueria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Controllers
{
    public class VisualizadorController : Controller
    {
        private readonly PeluqueriaDatabaseContext _context;

        public VisualizadorController(PeluqueriaDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VisualizadorPeluquerosSolicitadosAsync()
        {
            var turnos = await _context.Turno.Include(t => t.Servicio).ToListAsync();

            var peluquerosIds = turnos.Select(t => t.PeluqueroId).Distinct().ToList();

            var nombresPeluqueros = await _context.Usuarios
                .Where(p => peluquerosIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id, p => p.NombreCompleto);

            var turnosPorPeluquero = turnos
                .GroupBy(t => t.PeluqueroId)
                .Select(g => new PeluqueroEstadistica(g.Count(), nombresPeluqueros.GetValueOrDefault(g.Key, "Sin nombre")))
                .ToList();

            return View(turnosPorPeluquero);
        }

        public async Task<IActionResult> VisualizadorTurnosSolicitados()
        {
            var turnos = await _context.Turno.ToListAsync(); 

            var peluqueriaDatabaseContext = turnos
                .GroupBy(t => new { t.FechaHora.Year, t.FechaHora.Month }) 
                .Select(g => new TurnoEstadistica(g.Key.Year, g.Key.Month, g.Count()))
                .OrderBy(g => g.Año)
                .ThenBy(g => g.Mes)
                .ToList();

            return View(peluqueriaDatabaseContext);
        }

        public async Task<IActionResult> VisualizadorServiciosSolicitadosAsync()
        {
            var turnos = await _context.Turno.Include(t => t.Servicio).ToListAsync();

            var serviciosIds = turnos.Select(t => t.ServicioId).Distinct().ToList();
            var servicios = await _context.Servicio.Where(s => serviciosIds.Contains(s.Id)).ToListAsync();

            var turnosPorServicio = turnos
                .GroupBy(t => t.ServicioId)
                .Select(g => new ServicioEstadistica(g.Count(), servicios.FirstOrDefault(s => s.Id == g.Key).Descripcion))
                .ToList();

            return View(turnosPorServicio);
        }

        public async Task<IActionResult> VisualizadorPreciosServiciosAsync()
        {
            var turnos = await _context.Turno.Include(t => t.Servicio).ToListAsync();

            var serviciosIds = turnos.Select(t => t.ServicioId).Distinct().ToList();
            var servicios = await _context.Servicio.Where(s => serviciosIds.Contains(s.Id)).ToListAsync();

            var turnosPorServicio = turnos
             .GroupBy(t => t.ServicioId)
             .Select(g => new ServicioEstadistica(
                 g.Count(),
                 servicios.FirstOrDefault(s => s.Id == g.Key)?.Descripcion ?? string.Empty,
                 g.Sum(t => servicios.FirstOrDefault(s => s.Id == g.Key)?.Precio ?? 0)
             ))
             .ToList();
            var sumaTotal = turnosPorServicio.Sum(t => t.PrecioTotal);

            ViewData["SumaTotal"] = sumaTotal;

            return View(turnosPorServicio);
        }
    }
}

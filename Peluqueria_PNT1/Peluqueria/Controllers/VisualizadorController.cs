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

        public IActionResult VisualizadorPeluquerosSolicitados()
        {
            return View();
        }

        public async Task<IActionResult> VisualizadorTurnosSolicitados()
        {
            var turnos = await _context.Turno.ToListAsync(); // Traer los turnos desde la base de datos

            var peluqueriaDatabaseContext = turnos
                .GroupBy(t => new { t.FechaHora.Year, t.FechaHora.Month }) // Realizar la agrupación en memoria
                .Select(g => new TurnoEstadistica(g.Key.Year, g.Key.Month, g.Count()))
                .OrderBy(g => g.Año)
                .ThenBy(g => g.Mes)
                .ToList();

            return View(peluqueriaDatabaseContext);
        }

        public IActionResult VisualizadorServiciosSolicitados()
        {
            return View();
        }
    }
}

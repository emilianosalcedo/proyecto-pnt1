using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Peluqueria.Context;
using Peluqueria.Models;
using Microsoft.AspNetCore.Http;

namespace Peluqueria.Controllers
{
    public class TurnoController : Controller
    {
        private readonly PeluqueriaDatabaseContext _context;

        public TurnoController(PeluqueriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Turno
        public async Task<IActionResult> IndexTurno()
        {
            string usuarioLogueado = HttpContext.Session.GetString("Usuario");
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(usuarioLogueado);
            int id = usuario.Id;
            Rol rol = usuario.Rol;
            if (rol == Rol.PELUQUERO)
            {
                var peluqueriaDatabaseContext = _context.Turno.Include(t => t.Cliente).Include(t => t.Servicio).Where(t => t.PeluqueroId == id);
                return View(await peluqueriaDatabaseContext.ToListAsync());
            }
            else if (rol == Rol.CLIENTE)
            {
                var peluqueriaDatabaseContext = _context.Turno.Include(t => t.Cliente).Include(t => t.Servicio).Where(t => t.ClienteId == id);
                return View(await peluqueriaDatabaseContext.ToListAsync());
            }
            else if (rol == Rol.ADMINISTRADOR) {
                var peluqueriaDatabaseContext = _context.Turno.Include(t => t.Cliente).Include(t => t.Servicio);
                return View(await peluqueriaDatabaseContext.ToListAsync());
            }
            return null;
        }

        // GET: Turno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turno
                .Include(t => t.Cliente)
                .Include(t => t.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // GET: Turno/Create
        public IActionResult Create()
        {
            ViewData["PeluqueroId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.PELUQUERO), "Id", "NombreCompleto");
            ViewData["ClienteId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.CLIENTE), "Id", "Nombre");
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "Id", "Descripcion");
            return View();
        }

        // POST: Turno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHora,Atendido,ServicioId,ClienteId,PeluqueroId")] Turno turno)
        {
            string usuarioLogueado = HttpContext.Session.GetString("Usuario");
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(usuarioLogueado);
            int id = usuario.Id;
            Rol rol = usuario.Rol;

            if (rol != Rol.ADMINISTRADOR) {
                turno.Atendido = false;
                var turnoEncontrado = _context.Turno.FirstOrDefault(t => (t.FechaHora == turno.FechaHora && t.ClienteId == turno.ClienteId) || (t.FechaHora == turno.FechaHora && t.PeluqueroId == turno.PeluqueroId));
                if (turnoEncontrado != null)
                    ModelState.AddModelError("", "Ese turno esta ocupado.");
                if (turno.FechaHora < DateTime.Now)
                    ModelState.AddModelError("", "La fecha deberia ser mayor al dia de hoy.");
            }
            if (rol == Rol.CLIENTE)
            {
                turno.ClienteId = usuario.Id;
            }
            else if (rol == Rol.PELUQUERO) {
                turno.PeluqueroId = usuario.Id;
            }

            if (ModelState.IsValid)
            {
                _context.Add(turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexTurno));
            }

            ViewData["PeluqueroId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.PELUQUERO), "Id", "Nombre", turno.PeluqueroId);
            ViewData["ClienteId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.CLIENTE), "Id", "Nombre", turno.ClienteId);
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "Id", "Descripcion", turno.ServicioId);
            return View(turno);
        }


        // GET: Turno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turno.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            ViewData["PeluqueroId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.PELUQUERO), "Id", "Nombre", turno.PeluqueroId);
            ViewData["ClienteId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.CLIENTE), "Id", "Nombre", turno.ClienteId);
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "Id", "Descripcion", turno.ServicioId);
            return View(turno);
        }

        // POST: Turno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,Atendido,ServicioId,ClienteId,PeluqueroId")] Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexTurno));
            }
            ViewData["PeluqueroId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.PELUQUERO), "Id", "Nombre");
            ViewData["ClienteId"] = new SelectList(_context.Usuarios.Where(u => u.Rol == Rol.CLIENTE), "Id", "Nombre");
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "Id", "Descripcion", turno.ServicioId);
            return View(turno);
        }

        // GET: Turno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turno
                .Include(t => t.Cliente)
                .Include(t => t.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turno.FindAsync(id);
            _context.Turno.Remove(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexTurno));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turno.Any(e => e.Id == id);
        }
    }
}

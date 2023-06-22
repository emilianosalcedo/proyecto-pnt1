using Microsoft.AspNetCore.Mvc;
using Peluqueria.Context;
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

        public IActionResult VisualizadorTurnosSolicitados()
        {
            return View();
        }

        public IActionResult VisualizadorServiciosSolicitados()
        {
            return View();
        }
    }
}

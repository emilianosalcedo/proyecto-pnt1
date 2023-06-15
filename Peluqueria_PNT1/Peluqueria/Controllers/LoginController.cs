using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Peluqueria.Context;
using Peluqueria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Peluqueria.Controllers
{
    public class LoginController : Controller
    {
        private readonly PeluqueriaDatabaseContext _context;
        public LoginController(PeluqueriaDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult IniciarSesion()
        {
            return View();
        }

        // POST: /Login/IniciarSesion
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.FirstOrDefaultAsync(m => m.Email == usuario.Email && m.Contrasenia == usuario.Contrasenia);
            if (usuarioEncontrado != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Email),
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                string usuarioJson = JsonConvert.SerializeObject(usuarioEncontrado.Result); 

                HttpContext.Session.SetString("Usuario", usuarioJson);
               
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                switch(usuarioEncontrado.Result.Rol)
                {
                    case Rol.ADMINISTRADOR:
                        return RedirectToAction("Index", "Home");
                    case Rol.CLIENTE:
                        return RedirectToAction("Cliente", "Home");
                    case Rol.PELUQUERO:
                        return RedirectToAction("Peluquero", "Home");
                }          
            }

            ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
            return View(usuario);
        }

        // GET: /Home/CerrarSesion
        public async Task<ActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Login");
        }
    }
}

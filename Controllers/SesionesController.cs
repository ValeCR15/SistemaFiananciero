using SistemaFinanciero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFinanciero.Controllers
{
    public class SesionesController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: Sesiones
        public ActionResult Login()
        {
            return View();
        }


        // POST: Sesiones/Create
        [HttpPost]
        public ActionResult Create(Usuario user)
        {
            try
            {
                // Verificar si el usuario y la contraseña son válidos en la base de datos
                var usuarioEncontrado = db.Usuarios.FirstOrDefault(u => u.correo == user.correo && u.contrasena == user.contrasena);

                if (usuarioEncontrado != null)
                {
                    Session["Rol"] = usuarioEncontrado.rol_id;
                    Session["Correo"] = usuarioEncontrado.correo;
                    // Usuario autenticado, redirigir a la página principal o a donde sea necesario
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Usuario no encontrado o contraseña incorrecta, retornar a la vista de login con un mensaje de error
                    ViewBag.Error = "Usuario o contraseña incorrectos.";
                    return View("Login");
                }
            }
            catch
            {
                return View();
            }
        }

    }
}

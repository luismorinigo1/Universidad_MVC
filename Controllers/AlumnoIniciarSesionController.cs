using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class AlumnoIniciarSesionController : Controller
    {
        // GET: AlumnoIniciarSesion
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult LoginALUMN(string DNI, string Legajo)
        {
            if (!string.IsNullOrEmpty(DNI) && !string.IsNullOrEmpty(Legajo))
            {
                DataBaseAlumnos db = new DataBaseAlumnos();

                var useralum = db.User_Students.FirstOrDefault(e => e.Dni == DNI && e.Filee == Legajo);

                if (useralum != null)
                {
                    FormsAuthentication.SetAuthCookie(useralum.Dni, true);
                    return RedirectToAction("Index", "MenuALUM");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "No encontramos tus datos" });
                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Llena los campos para poder iniciar sesion" });
            }


        }

        //[Authorize]
        //public ActionResult LogoutA()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Index");
        //}

    }
}
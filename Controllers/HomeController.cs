using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;
using System.Web.Security;

namespace Universidad.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string Contraseña)
        {
            if (!string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contraseña))
            {
                DataBase db = new DataBase();

                var useradm = db.User_Administrator.FirstOrDefault(e => e.Username == Usuario && e.Passwordd == Contraseña);

                if (useradm != null)
                {
                    FormsAuthentication.SetAuthCookie(useradm.Username, true);
                    return RedirectToAction("Index", "MenuADM");
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

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

       

        


    }
}
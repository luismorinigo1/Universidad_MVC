using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class VerUsuarioADMController : Controller
    {
        // GET: VerUsuarioADM
        public ActionResult Index()
        {
            DataBase db = new DataBase();

            var listusuarioAdm = db.User_Administrator.ToList();

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = listusuarioAdm
            };
        }
    }
}
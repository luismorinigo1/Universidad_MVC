using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Universidad.Controllers
{
    [Authorize]
    public class MenuADMController : Controller
    {
        // GET: MenuADM
        public ActionResult Index()
        {
            return View();
        }
    }
}
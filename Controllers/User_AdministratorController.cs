using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class User_AdministratorController : Controller
    {
        private DataBase db = new DataBase();

        // GET: User_Administrator
        public ActionResult Index()
        {
            return View(db.User_Administrator.ToList());
        }

        // GET: User_Administrator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Administrator user_Administrator = db.User_Administrator.Find(id);
            if (user_Administrator == null)
            {
                return HttpNotFound();
            }
            return View(user_Administrator);
        }

        // GET: User_Administrator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Administrator/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_User,Username,Passwordd")] User_Administrator user_Administrator)
        {
            if (ModelState.IsValid)
            {
                db.User_Administrator.Add(user_Administrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_Administrator);
        }

        // GET: User_Administrator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Administrator user_Administrator = db.User_Administrator.Find(id);
            if (user_Administrator == null)
            {
                return HttpNotFound();
            }
            return View(user_Administrator);
        }

        // POST: User_Administrator/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_User,Username,Passwordd")] User_Administrator user_Administrator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Administrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Administrator);
        }

        // GET: User_Administrator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Administrator user_Administrator = db.User_Administrator.Find(id);
            if (user_Administrator == null)
            {
                return HttpNotFound();
            }
            return View(user_Administrator);
        }

        // POST: User_Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Administrator user_Administrator = db.User_Administrator.Find(id);
            db.User_Administrator.Remove(user_Administrator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

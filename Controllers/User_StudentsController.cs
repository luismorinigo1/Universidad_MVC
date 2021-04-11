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
    public class User_StudentsController : Controller
    {
        private DataBaseAlumnos db = new DataBaseAlumnos();

        // GET: User_Students
        public ActionResult Index()
        {
            return View(db.User_Students.ToList());
        }

        // GET: User_Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Students user_Students = db.User_Students.Find(id);
            if (user_Students == null)
            {
                return HttpNotFound();
            }
            return View(user_Students);
        }

        // GET: User_Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Students/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_User,Namee,Surname,Dni,Filee,Subjects")] User_Students user_Students)
        {
            if (ModelState.IsValid)
            {
                db.User_Students.Add(user_Students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_Students);
        }

        // GET: User_Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Students user_Students = db.User_Students.Find(id);
            if (user_Students == null)
            {
                return HttpNotFound();
            }
            return View(user_Students);
        }

        // POST: User_Students/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_User,Namee,Surname,Dni,Filee,Subjects")] User_Students user_Students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Students);
        }

        // GET: User_Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Students user_Students = db.User_Students.Find(id);
            if (user_Students == null)
            {
                return HttpNotFound();
            }
            return View(user_Students);
        }

        // POST: User_Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Students user_Students = db.User_Students.Find(id);
            db.User_Students.Remove(user_Students);
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

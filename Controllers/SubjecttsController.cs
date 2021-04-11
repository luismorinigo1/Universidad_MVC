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
    public class SubjecttsController : Controller
    {
        private DataBaseMaterias db = new DataBaseMaterias();

        // GET: Subjectts
        public ActionResult Index()
        {
            return View(db.Subjectt.ToList());
        }

        // GET: Subjectts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjectt subjectt = db.Subjectt.Find(id);
            if (subjectt == null)
            {
                return HttpNotFound();
            }
            return View(subjectt);
        }

        // GET: Subjectts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjectts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Subject,namee,hour_hand,Teacher,maximum_students")] Subjectt subjectt)
        {
            if (ModelState.IsValid)
            {
                db.Subjectt.Add(subjectt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subjectt);
        }

        // GET: Subjectts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjectt subjectt = db.Subjectt.Find(id);
            if (subjectt == null)
            {
                return HttpNotFound();
            }
            return View(subjectt);
        }

        // POST: Subjectts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Subject,namee,hour_hand,Teacher,maximum_students")] Subjectt subjectt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subjectt);
        }

        // GET: Subjectts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjectt subjectt = db.Subjectt.Find(id);
            if (subjectt == null)
            {
                return HttpNotFound();
            }
            return View(subjectt);
        }

        // POST: Subjectts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subjectt subjectt = db.Subjectt.Find(id);
            db.Subjectt.Remove(subjectt);
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

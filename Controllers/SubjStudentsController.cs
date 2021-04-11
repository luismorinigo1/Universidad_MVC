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
    public class SubjStudentsController : Controller
    {
        private DataBaseAnotadorMaterias db = new DataBaseAnotadorMaterias();

        // GET: SubjStudents
        public ActionResult Index()
        {
            return View(db.SubjStudent.ToList());
        }

        // GET: SubjStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjStudent subjStudent = db.SubjStudent.Find(id);
            if (subjStudent == null)
            {
                return HttpNotFound();
            }
            return View(subjStudent);
        }

        // GET: SubjStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjStudents/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_subj,Dni,Subjects")] SubjStudent subjStudent)
        {
            if (ModelState.IsValid)
            {
                db.SubjStudent.Add(subjStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subjStudent);
        }

        // GET: SubjStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjStudent subjStudent = db.SubjStudent.Find(id);
            if (subjStudent == null)
            {
                return HttpNotFound();
            }
            return View(subjStudent);
        }

        // POST: SubjStudents/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_subj,Dni,Subjects")] SubjStudent subjStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subjStudent);
        }

        // GET: SubjStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjStudent subjStudent = db.SubjStudent.Find(id);
            if (subjStudent == null)
            {
                return HttpNotFound();
            }
            return View(subjStudent);
        }

        // POST: SubjStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjStudent subjStudent = db.SubjStudent.Find(id);
            db.SubjStudent.Remove(subjStudent);
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

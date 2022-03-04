using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Management_systems.Models;

namespace Student_Management_systems.Controllers
{
    [Authorize]
    public class ClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Class
        public ActionResult Index()
        {
            var classModels = db.ClassModels.Include(c => c.TrainerModels);
            return View(classModels.ToList());
        }


        // GET: Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModels classModels = db.ClassModels.Find(id);
            if (classModels == null)
            {
                return HttpNotFound();
            }
            return View(classModels);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            ViewBag.TrainerId = new SelectList(db.TrainerModels, "TrainerId", "TrainerFullName");
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,Descriptions,Course_Name,TrainerId")] ClassModels classModels)
        {
            if (ModelState.IsValid)
            {
                db.ClassModels.Add(classModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrainerId = new SelectList(db.TrainerModels, "TrainerId", "TrainerFullName", classModels.TrainerId);
            return View(classModels);
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModels classModels = db.ClassModels.Find(id);
            if (classModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainerId = new SelectList(db.TrainerModels, "TrainerId", "TrainerFullName", classModels.TrainerId);
            return View(classModels);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,Descriptions,Course_Name,TrainerId")] ClassModels classModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrainerId = new SelectList(db.TrainerModels, "TrainerId", "TrainerFullName", classModels.TrainerId);
            return View(classModels);
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModels classModels = db.ClassModels.Find(id);
            if (classModels == null)
            {
                return HttpNotFound();
            }
            return View(classModels);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassModels classModels = db.ClassModels.Find(id);
            db.ClassModels.Remove(classModels);
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

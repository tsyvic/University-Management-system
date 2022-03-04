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
    public class TrainerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        // GET: Trainer
        public ActionResult Index()
        {
            return View(db.TrainerModels.ToList());
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerModels trainerModels = db.TrainerModels.Find(id);
            if (trainerModels == null)
            {
                return HttpNotFound();
            }
            return View(trainerModels);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerId,TrainerIdNum,TrainerFullName,DateofBirth,PhoneNumber,Address")] TrainerModels trainerModels)
        {
            if (ModelState.IsValid)
            {
                db.TrainerModels.Add(trainerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainerModels);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerModels trainerModels = db.TrainerModels.Find(id);
            if (trainerModels == null)
            {
                return HttpNotFound();
            }
            return View(trainerModels);
        }

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerId,TrainerIdNum,TrainerFullName,DateofBirth,PhoneNumber,Address")] TrainerModels trainerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainerModels);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerModels trainerModels = db.TrainerModels.Find(id);
            if (trainerModels == null)
            {
                return HttpNotFound();
            }
            return View(trainerModels);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerModels trainerModels = db.TrainerModels.Find(id);
            db.TrainerModels.Remove(trainerModels);
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

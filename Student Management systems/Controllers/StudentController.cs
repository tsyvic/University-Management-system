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
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        // GET: Student
        public ActionResult Index()
        {
            var studentModels = db.StudentModels.Include(s => s.ClassModels);
            return View(studentModels.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentModels = db.StudentModels.Find(id);
            if (studentModels == null)
            {
                return HttpNotFound();
            }
            return View(studentModels);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentIdNum,StudentFullName,DateofBirth,PhoneNumber,Address,ClassId")] StudentModels studentModels)
        {
            if (ModelState.IsValid)
            {
                db.StudentModels.Add(studentModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name", studentModels.ClassId);
            return View(studentModels);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentModels = db.StudentModels.Find(id);
            if (studentModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name", studentModels.ClassId);
            return View(studentModels);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentIdNum,StudentFullName,DateofBirth,PhoneNumber,Address,ClassId")] StudentModels studentModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name", studentModels.ClassId);
            return View(studentModels);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentModels = db.StudentModels.Find(id);
            if (studentModels == null)
            {
                return HttpNotFound();
            }
            return View(studentModels);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentModels studentModels = db.StudentModels.Find(id);
            db.StudentModels.Remove(studentModels);
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

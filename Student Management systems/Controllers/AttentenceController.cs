using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Student_Management_systems.Models;

namespace Student_Management_systems.Controllers
{
    [Authorize]
    public class AttentenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attentence
        public async Task<ActionResult> Index(string C)
        {
            GeneralViewModel ca = new GeneralViewModel();
            ca.AttentenceModels = db.AttentenceModels.Include(a => a.StudentModels).Include(a => a.StudentModels.ClassModels);
            ca.ClassModels = db.ClassModels;

            

            if (!C.IsNullOrWhiteSpace())
            {
                int q = Int32.Parse(C);
                ca.AttentenceModels = ca.AttentenceModels.Where(s => s.StudentModels.ClassModels.ClassId.Equals(q));

            }
            return View(ca);
            
        }

        // GET: Attentence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttentenceModels attentenceModels = db.AttentenceModels.Find(id);
            if (attentenceModels == null)
            {
                return HttpNotFound();
            }
            return View(attentenceModels);
        }

        // GET: Attentence/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name");
            ViewBag.StudentId = new SelectList(db.StudentModels, "StudentId", "StudentFullName");
            return View();
        }

        // POST: Attentence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttentenceId,Date,Start_Time,End_Time,Comments,Status,StudentId")] AttentenceModels attentenceModels)
        {
            if (ModelState.IsValid)
            {
                db.AttentenceModels.Add(attentenceModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.StudentModels, "StudentId", "StudentFullName", attentenceModels.StudentId);
            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name");
            return View(attentenceModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Percent()
        {
            return View();
        }

        // GET: Attentence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttentenceModels attentenceModels = db.AttentenceModels.Find(id);
            if (attentenceModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.StudentModels, "StudentId", "StudentFullName", attentenceModels.StudentId);
            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name");
            return View(attentenceModels);
        }

        // POST: Attentence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttentenceId,Date,Start_Time,End_Time,Comments,Status,StudentId")] AttentenceModels attentenceModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attentenceModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.StudentModels, "StudentId", "StudentFullName", attentenceModels.StudentId);
            ViewBag.ClassId = new SelectList(db.ClassModels, "ClassId", "Course_Name");
            return View(attentenceModels);
        }

        // GET: Attentence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttentenceModels attentenceModels = db.AttentenceModels.Find(id);
            if (attentenceModels == null)
            {
                return HttpNotFound();
            }
            return View(attentenceModels);
        }

        // POST: Attentence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttentenceModels attentenceModels = db.AttentenceModels.Find(id);
            db.AttentenceModels.Remove(attentenceModels);
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

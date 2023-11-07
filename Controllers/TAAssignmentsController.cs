using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SRSWebApplication.Models;

namespace SRSWebApplication.Controllers
{
    public class TAAssignmentsController : Controller
    {
        private SRSDBEntities db = new SRSDBEntities();

        // GET: TAAssignments
        public ActionResult Index()
        {
            var tAAssignments = db.TAAssignments.Include(t => t.Courses).Include(t => t.StudyTerms).Include(t => t.TAGraders);
            return View(tAAssignments.ToList());
        }

        // GET: TAAssignments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAAssignments tAAssignments = db.TAAssignments.Find(id);
            if (tAAssignments == null)
            {
                return HttpNotFound();
            }
            return View(tAAssignments);
        }

        // GET: TAAssignments/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName");
            ViewBag.TAID = new SelectList(db.TAGraders, "TAID", "TAFirstName");
            return View();
        }

        // POST: TAAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TAAssignmentID,TAID,CourseID,TermID,AssignmentDate")] TAAssignments tAAssignments)
        {
            if (ModelState.IsValid)
            {
                db.TAAssignments.Add(tAAssignments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", tAAssignments.CourseID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", tAAssignments.TermID);
            ViewBag.TAID = new SelectList(db.TAGraders, "TAID", "TAFirstName", tAAssignments.TAID);
            return View(tAAssignments);
        }

        // GET: TAAssignments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAAssignments tAAssignments = db.TAAssignments.Find(id);
            if (tAAssignments == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", tAAssignments.CourseID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", tAAssignments.TermID);
            ViewBag.TAID = new SelectList(db.TAGraders, "TAID", "TAFirstName", tAAssignments.TAID);
            return View(tAAssignments);
        }

        // POST: TAAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TAAssignmentID,TAID,CourseID,TermID,AssignmentDate")] TAAssignments tAAssignments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAAssignments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", tAAssignments.CourseID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", tAAssignments.TermID);
            ViewBag.TAID = new SelectList(db.TAGraders, "TAID", "TAFirstName", tAAssignments.TAID);
            return View(tAAssignments);
        }

        // GET: TAAssignments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAAssignments tAAssignments = db.TAAssignments.Find(id);
            if (tAAssignments == null)
            {
                return HttpNotFound();
            }
            return View(tAAssignments);
        }

        // POST: TAAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAAssignments tAAssignments = db.TAAssignments.Find(id);
            db.TAAssignments.Remove(tAAssignments);
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

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
    public class InstructorsController : Controller
    {
        private SRSDBEntities db = new SRSDBEntities();

        // GET: Instructors
        public ActionResult Index()
        {
            var instructors = db.Instructors.Include(i => i.Departments);
            return View(instructors.ToList());
        }

        // GET: Instructors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructors instructors = db.Instructors.Find(id);
            if (instructors == null)
            {
                return HttpNotFound();
            }
            return View(instructors);
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,InstructorFirstName,InstructorLastName,InstructorPhone,InstructorEmail,DepartmentID")] Instructors instructors)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", instructors.DepartmentID);
            return View(instructors);
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructors instructors = db.Instructors.Find(id);
            if (instructors == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", instructors.DepartmentID);
            return View(instructors);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,InstructorFirstName,InstructorLastName,InstructorPhone,InstructorEmail,DepartmentID")] Instructors instructors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", instructors.DepartmentID);
            return View(instructors);
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructors instructors = db.Instructors.Find(id);
            if (instructors == null)
            {
                return HttpNotFound();
            }
            return View(instructors);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Instructors instructors = db.Instructors.Find(id);
            db.Instructors.Remove(instructors);
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

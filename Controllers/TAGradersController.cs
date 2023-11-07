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
    public class TAGradersController : Controller
    {
        private SRSDBEntities db = new SRSDBEntities();

        // GET: TAGraders
        public ActionResult Index()
        {
            var tAGraders = db.TAGraders.Include(t => t.Departments);
            return View(tAGraders.ToList());
        }

        // GET: TAGraders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAGraders tAGraders = db.TAGraders.Find(id);
            if (tAGraders == null)
            {
                return HttpNotFound();
            }
            return View(tAGraders);
        }

        // GET: TAGraders/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: TAGraders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TAID,TAFirstName,TALastName,TAPhone,TAEmail,DepartmentID")] TAGraders tAGraders)
        {
            if (ModelState.IsValid)
            {
                db.TAGraders.Add(tAGraders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", tAGraders.DepartmentID);
            return View(tAGraders);
        }

        // GET: TAGraders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAGraders tAGraders = db.TAGraders.Find(id);
            if (tAGraders == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", tAGraders.DepartmentID);
            return View(tAGraders);
        }

        // POST: TAGraders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TAID,TAFirstName,TALastName,TAPhone,TAEmail,DepartmentID")] TAGraders tAGraders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAGraders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", tAGraders.DepartmentID);
            return View(tAGraders);
        }

        // GET: TAGraders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAGraders tAGraders = db.TAGraders.Find(id);
            if (tAGraders == null)
            {
                return HttpNotFound();
            }
            return View(tAGraders);
        }

        // POST: TAGraders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAGraders tAGraders = db.TAGraders.Find(id);
            db.TAGraders.Remove(tAGraders);
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

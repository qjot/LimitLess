using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Limitless.Data;
using Limitless.Model;

namespace ManagementApp.Controllers
{
    public class HallController : Controller
    {
        private LimitlessEntities db = new LimitlessEntities();

        // GET: Hall
        public ActionResult Index()
        {
            return View(db.halls.ToList());
        }

        // GET: Hall/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: Hall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hall/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hallId,name,maxCapacity,userId")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.halls.Add(hall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hall);
        }

        // GET: Hall/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Hall/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hallId,name,maxCapacity,userId")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hall);
        }

        // GET: Hall/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Hall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hall hall = db.halls.Find(id);
            db.halls.Remove(hall);
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

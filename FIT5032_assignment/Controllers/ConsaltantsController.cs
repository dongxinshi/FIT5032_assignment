using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_assignment.Models;

namespace FIT5032_assignment.Controllers
{
    public class ConsaltantsController : Controller
    {
        private Entities db = new Entities();

        // GET: Consaltants
        public ActionResult Index()
        {
            return View(db.ConsaltantSet1.ToList());
        }

        // GET: Consaltants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consaltant consaltant = db.ConsaltantSet1.Find(id);
            if (consaltant == null)
            {
                return HttpNotFound();
            }
            return View(consaltant);
        }

        // GET: Consaltants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consaltants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,Email,PhoneNumber")] Consaltant consaltant)
        {
            if (ModelState.IsValid)
            {
                db.ConsaltantSet1.Add(consaltant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consaltant);
        }

        // GET: Consaltants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consaltant consaltant = db.ConsaltantSet1.Find(id);
            if (consaltant == null)
            {
                return HttpNotFound();
            }
            return View(consaltant);
        }

        // POST: Consaltants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,Email,PhoneNumber")] Consaltant consaltant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consaltant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consaltant);
        }

        // GET: Consaltants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consaltant consaltant = db.ConsaltantSet1.Find(id);
            if (consaltant == null)
            {
                return HttpNotFound();
            }
            return View(consaltant);
        }

        // POST: Consaltants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consaltant consaltant = db.ConsaltantSet1.Find(id);
            db.ConsaltantSet1.Remove(consaltant);
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

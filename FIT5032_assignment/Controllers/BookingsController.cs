﻿using System;
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
    public class BookingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookingSet = db.BookingSet.Include(b => b.AspNetUsers).Include(b => b.Consaltant);
            return View(bookingSet.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.BookingSet.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ConsaltantId = new SelectList(db.ConsaltantSet1, "Id", "name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,time,AspNetUsersId,ConsaltantId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.BookingSet.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", booking.AspNetUsersId);
            ViewBag.ConsaltantId = new SelectList(db.ConsaltantSet1, "Id", "name", booking.ConsaltantId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.BookingSet.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", booking.AspNetUsersId);
            ViewBag.ConsaltantId = new SelectList(db.ConsaltantSet1, "Id", "name", booking.ConsaltantId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,time,AspNetUsersId,ConsaltantId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", booking.AspNetUsersId);
            ViewBag.ConsaltantId = new SelectList(db.ConsaltantSet1, "Id", "name", booking.ConsaltantId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.BookingSet.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.BookingSet.Find(id);
            db.BookingSet.Remove(booking);
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

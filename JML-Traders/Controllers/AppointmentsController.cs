﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JML_Traders.Models;

namespace JML_Traders.Controllers
{
    public class AppointmentsController : Controller
    {
        private DatabaseJMLTradersEntities db = new DatabaseJMLTradersEntities();

        // GET: Appointments
        public ActionResult listAppointments()
        {
            var af458_appointments = db.af458_appointments.Include(a => a.af458_brokers).Include(a => a.af458_customers);
            return View(af458_appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Appointment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_appointments af458_appointments = db.af458_appointments.Find(id);
            if (af458_appointments == null)
            {
                return HttpNotFound();
            }
            return View(af458_appointments);
        }

        // GET: Appointments/Create
        public ActionResult AddAppointment()
        {
            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname");
            ViewBag.id_af458_customers = new SelectList(db.af458_customers, "id", "lastname");
            return View();
        }

        // POST: Appointments/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointment([Bind(Include = "id,dateHour,subject,id_af458_brokers,id_af458_customers")] af458_appointments af458_appointments)
        {
            if (ModelState.IsValid)
            {
                db.af458_appointments.Add(af458_appointments);
                db.SaveChanges();
                return RedirectToAction("listAppointments");
            }

            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname", af458_appointments.id_af458_brokers);
            ViewBag.id_af458_customers = new SelectList(db.af458_customers, "id", "lastname", af458_appointments.id_af458_customers);
            return View(af458_appointments);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_appointments af458_appointments = db.af458_appointments.Find(id);
            if (af458_appointments == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname", af458_appointments.id_af458_brokers);
            ViewBag.id_af458_customers = new SelectList(db.af458_customers, "id", "lastname", af458_appointments.id_af458_customers);
            return View(af458_appointments);
        }

        // POST: Appointments/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,dateHour,subject,id_af458_brokers,id_af458_customers")] af458_appointments af458_appointments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(af458_appointments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname", af458_appointments.id_af458_brokers);
            ViewBag.id_af458_customers = new SelectList(db.af458_customers, "id", "lastname", af458_appointments.id_af458_customers);
            return View(af458_appointments);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_appointments af458_appointments = db.af458_appointments.Find(id);
            if (af458_appointments == null)
            {
                return HttpNotFound();
            }
            return View(af458_appointments);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            af458_appointments af458_appointments = db.af458_appointments.Find(id);
            db.af458_appointments.Remove(af458_appointments);
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

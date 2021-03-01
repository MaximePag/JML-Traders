using System;
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
    public class BrokersController : Controller
    {
        private DatabaseJMLTradersEntities db = new DatabaseJMLTradersEntities();

        public ActionResult addBrokers()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addBrokers([Bind(Include = "id,lastname,firstname,mail,phoneNumber")] af458_brokers af458_brokers)
        {
            if (ModelState.IsValid)
            {
                db.af458_brokers.Add(af458_brokers);
                db.SaveChanges();
                return RedirectToAction("listBrokers");
            }
            else
            {
                return View(af458_brokers);
            }
        }

        // GET: Brokers
        public ActionResult listBrokers()
        {
            return View(db.af458_brokers.ToList());
        }

        // GET: Brokers/profilBrokers/5
        public ActionResult profilBrokers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_brokers af458_brokers = db.af458_brokers.Find(id);
            if (af458_brokers == null)
            {
                return HttpNotFound();
            }
            return View(af458_brokers);
        }

        // POST: Brokers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: Brokers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_brokers af458_brokers = db.af458_brokers.Find(id);
            if (af458_brokers == null)
            {
                return HttpNotFound();
            }
            return View(af458_brokers);
        }

        // POST: Brokers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,lastname,firstname,mail,phoneNumber")] af458_brokers af458_brokers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(af458_brokers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listBrokers");
            }
            return View(af458_brokers);
        }

        // GET: Brokers/Delete/5
        public ActionResult Delete(int? id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_brokers af458_brokers = db.af458_brokers.Find(id);
            if (af458_brokers == null)
            {
                return HttpNotFound();
            }
            return View(af458_brokers);
            */
            af458_brokers af458_brokers = db.af458_brokers.Find(id);
            db.af458_brokers.Remove(af458_brokers);
            db.SaveChanges();
            return RedirectToAction("listBrokers");

        }

        // POST: Brokers/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            af458_brokers af458_brokers = db.af458_brokers.Find(id);
            db.af458_brokers.Remove(af458_brokers);
            db.SaveChanges();
            return RedirectToAction("listBrokers");
        }
        */
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

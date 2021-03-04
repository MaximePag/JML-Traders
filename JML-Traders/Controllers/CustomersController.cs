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
    public class CustomersController : Controller
    {
        private DatabaseJMLTradersEntities db = new DatabaseJMLTradersEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var af458_customers = db.af458_customers.Include(a => a.af458_brokers);
            return View(af458_customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult DetailsCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_customers af458_customers = db.af458_customers.Find(id);
            if (af458_customers == null)
            {
                return HttpNotFound();
            }
            return View(af458_customers);
        }

        // GET: Customers/Create
        public ActionResult addCustomer()
        {
            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname");
            return View();
        }

        // POST: Customers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addCustomer([Bind(Include = "id,lastname,firstname,mail,phoneNumber,budget,id_af458_brokers")] af458_customers af458_customers)
        {
            if (ModelState.IsValid)
            {
                db.af458_customers.Add(af458_customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname", af458_customers.id_af458_brokers);
            return View(af458_customers);
        }

        // GET: Customers/Edit/5
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            af458_customers af458_customers = db.af458_customers.Find(id);
            if (af458_customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname", af458_customers.id_af458_brokers);
            return View(af458_customers);
        }

        // POST: Customers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "id,lastname,firstname,mail,phoneNumber,budget,id_af458_brokers")] af458_customers af458_customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(af458_customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_af458_brokers = new SelectList(db.af458_brokers, "id", "lastname", af458_customers.id_af458_brokers);
            return View(af458_customers);
        }

        // GET: Customers/Delete/5
        public ActionResult DeleteCustomer(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //af458_customers af458_customers = db.af458_customers.Find(id);
            //if (af458_customers == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(af458_customers);
            af458_customers af458_customers = db.af458_customers.Find(id);
            db.af458_customers.Remove(af458_customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            af458_customers af458_customers = db.af458_customers.Find(id);
            db.af458_customers.Remove(af458_customers);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JML_Traders.Models;

namespace JML_Traders.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseJMLTradersEntities db = new DatabaseJMLTradersEntities();
        public ActionResult Index()
        {
            var af458_appointments = db.af458_appointments.SqlQuery("SELECT * FROM af458_appointments WHERE CONVERT(VARCHAR(25), dateHour, 126) = CONVERT(date, GETDATE()) ORDER BY CONVERT(VARCHAR(25), dateHour, 126) ASC");
            return View(af458_appointments.ToList());
        }
    }
}
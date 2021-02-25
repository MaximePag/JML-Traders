using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JML_Traders.Controllers
{
    public class BrokersController : Controller
    {
        // GET: Brokers
        public ActionResult Index()
        {
            return View();
        }
    }
}
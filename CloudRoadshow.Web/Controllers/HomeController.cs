using CloudRoadshow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CloudRoadshow.Web.Controllers
{
    public class HomeController : Controller
    {
        IInvoiceDS ds = new InvoiceDS();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {
            return Json(ds.GetAll().ToArray(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Insert(Invoice invoice)
        {
            ds.AddNew(invoice);
            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }
    }
}
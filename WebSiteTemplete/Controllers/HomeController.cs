using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteTemplete.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Main()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MainSetting()
        {

            return View();
        }
        public ActionResult WarningPage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult finance()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
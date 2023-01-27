using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteTemplete.Models;

namespace WebSiteTemplete.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var pageInfo = db.PageInfo.ToList();
            return View(pageInfo); 
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
        public ActionResult Main(int? id)
        {
            ViewBag.Message = "Your contact page.";
List<ContentInfo> contentlist = db.ContentInfo.ToList();
            ViewBag.ContentInfo = contentlist;
List<PageInfo> pageinfolist = db.PageInfo.ToList();
            ViewBag.PageInfolist = pageinfolist;
            if (id==null)
            {
                var a = 1;
                ViewBag.PageInfo = a;
                return View(db.PageDetails.ToList());
            }
            
            

            var pageInfo = id;
            ViewBag.PageInfo = pageInfo;
            return View(db.PageDetails.ToList());
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSiteTemplete.Models;

namespace WebSiteTemplete.Controllers
{
    public class AdminViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminViewModels
        public ActionResult Index()
        {
            ViewBag.UserType = "admin";
            Session["UserType"] = "admin";
            return View(db.MediaTypes.ToList());
        }

        // GET: AdminViewModels
        public ActionResult MainManagement()
        {
            ViewBag.UserType = "admin";
            Session["UserType"] = "admin";
            return View(db.MediaTypes.ToList());
        }
        // GET: AdminViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminViewModels adminViewModels=null;
            if (adminViewModels == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // GET: AdminViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MediaTypeName,MediaTypeAName,MediaTypeEName,url,UserId,MediaTypeID,ParaGrapheName,ParaGrapheAName,ParaGrapheEName,TextTypeID,TextTypeName,TextTypeAName,TextTypeEName,TitleName,TitleAName,TitleEName")] AdminViewModels adminViewModels)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(adminViewModels);
        }

        // GET: AdminViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminViewModels adminViewModels = null;
            if (adminViewModels == null)
            {
                return HttpNotFound();
            }
            return View(adminViewModels);
        }

        // POST: AdminViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MediaTypeName,MediaTypeAName,MediaTypeEName,url,UserId,MediaTypeID,ParaGrapheName,ParaGrapheAName,ParaGrapheEName,TextTypeID,TextTypeName,TextTypeAName,TextTypeEName,TitleName,TitleAName,TitleEName")] AdminViewModels adminViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminViewModels);
        }

        // GET: AdminViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminViewModels adminViewModels = null;
            if (adminViewModels == null)
            {
                return HttpNotFound();
            }
            return View(adminViewModels);
        }

        // POST: AdminViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
       
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

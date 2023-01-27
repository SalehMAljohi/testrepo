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
    public class ContentInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContentInfoes
        public ActionResult Index()
        {
            return View(db.ContentInfo.ToList());
        }

        // GET: ContentInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            if (contentInfo == null)
            {
                return HttpNotFound();
            }
            return View(contentInfo);
        }

        // GET: ContentInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContentInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ContentName,ContentAName,ContentEName")] ContentInfo contentInfo)
        {
            if (ModelState.IsValid)
            {
                db.ContentInfo.Add(contentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contentInfo);
        }

        // GET: ContentInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            if (contentInfo == null)
            {
                return HttpNotFound();
            }
            return View(contentInfo);
        }

        // POST: ContentInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ContentName,ContentAName,ContentEName")] ContentInfo contentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contentInfo);
        }

        // GET: ContentInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            if (contentInfo == null)
            {
                return HttpNotFound();
            }
            return View(contentInfo);
        }

        // POST: ContentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            db.ContentInfo.Remove(contentInfo);
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

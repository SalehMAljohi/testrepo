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
    public class PageInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PageInfoes
        public ActionResult Index()
        {
            return View(db.PageInfo.ToList());
        }

        // GET: PageInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageInfo pageInfo = db.PageInfo.Find(id);
            if (pageInfo == null)
            {
                return HttpNotFound();
            }
            return View(pageInfo);
        }

        // GET: PageInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PageInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PageName,PageAName,PageEName")] PageInfo pageInfo)
        {
            if (ModelState.IsValid)
            {
                db.PageInfo.Add(pageInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageInfo);
        }

        // GET: PageInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageInfo pageInfo = db.PageInfo.Find(id);
            if (pageInfo == null)
            {
                return HttpNotFound();
            }
            return View(pageInfo);
        }

        // POST: PageInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PageName,PageAName,PageEName")] PageInfo pageInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageInfo);
        }

        // GET: PageInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageInfo pageInfo = db.PageInfo.Find(id);
            if (pageInfo == null)
            {
                return HttpNotFound();
            }
            return View(pageInfo);
        }

        // POST: PageInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageInfo pageInfo = db.PageInfo.Find(id);
            db.PageInfo.Remove(pageInfo);
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

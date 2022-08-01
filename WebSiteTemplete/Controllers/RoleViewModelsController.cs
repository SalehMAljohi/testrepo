using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class RoleViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "admin,Owner")]

        // GET: RoleViewModels
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == userId).SingleOrDefault();
            if (CurrentUser.UserType == "admin")
            {
                ViewBag.UserType = "admin";
            }
            else if (CurrentUser.UserType == "Owner")
            {
                ViewBag.UserType = "Owner";
            }
            return View(db.Roles.ToList());
        }

        [HttpPost]
        public JsonResult Add(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return Json("1");
            }

            return Json(role);
        }

        [HttpPost]
        public JsonResult Update([Bind(Include = "Id,Name")] IdentityRole role)
        {

            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;

                db.SaveChanges();
                return Json("1");
            }
            return Json(role);
        }
        [HttpPost]
        public JsonResult Delete(IdentityRole role)
        {

            if (role == null)
            {
                return Json("0");
            }
            var myrole = db.Roles.Find(role.Id);
            db.Roles.Remove(myrole);
            db.SaveChanges();
            return Json("1");
        }


        //// GET: RoleViewModels/Details/5
        //public ActionResult Details(string id)
        //{
        //    var role = db.Roles.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //RoleViewModels roleViewModels = db.RoleViewModels.Find(id);
        //    //if (role)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View(role);
        //}

        // GET: RoleViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(role);

        }

        //// GET: RoleViewModels/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    var role = db.Roles.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role);
        //}

        //// POST: RoleViewModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(role).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(role);
        //}

        //    // GET: RoleViewModels/Delete/5
        //    public ActionResult Delete(string id)
        //{
        //    var role = db.Roles.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role);
        //}
        //// POST: Role/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(IdentityRole role)
        //{
        //    var myrole = db.Roles.Find(role.Id);
        //    db.Roles.Remove(myrole);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}


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

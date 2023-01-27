using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSiteTemplete.Models;

namespace WebSiteTemplete.Controllers
{
    public class PageDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private ApplicationDbContext db2 = new ApplicationDbContext();
        private ApplicationDbContext db3 = new ApplicationDbContext();
        [Authorize(Roles = "admin")]

        // GET: PageDetails
        public ActionResult Index()
        {
            var pageInfo = db.PageInfo.ToList();
            return View(pageInfo);
        }

        // GET: PageDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageDetails pageDetails = db.PageDetails.Find(id);
            if (pageDetails == null)
            {
                return HttpNotFound();
            }
            return View(pageDetails);
        }

        // GET: PageDetails/Create
        public ActionResult Create()
        {
            ViewBag.ContentID = new SelectList(db.ContentInfo, "ID", "ContentName");
            ViewBag.MediaSubTypeID = new SelectList(db.MediaSubTypes, "ID", "url");
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "ID", "MediaTypeName");
            ViewBag.PageID = new SelectList(db.PageInfo, "ID", "PageName");
            ViewBag.ParaGraphesID = new SelectList(db.ParaGraphes, "ID", "ParaGrapheName");
            ViewBag.TextTypeID = new SelectList(db.textTypes, "ID", "TextTypeName");
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "TitleName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType");
            return View();
        }

        // POST: PageDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,MediaTypeID,PageID,ContentID,MediaSubTypeID,TextTypeID,ParaGraphesID,TitleID")] PageDetails pageDetails, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                pageDetails.MediaSubTypes.url = upload.FileName;
                pageDetails.UserId = User.Identity.GetUserId();
                db.PageDetails.Add(pageDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentID = new SelectList(db.ContentInfo, "ID", "ContentName", pageDetails.ContentID);
            ViewBag.MediaSubTypeID = new SelectList(db.MediaSubTypes, "ID", "url", pageDetails.MediaSubTypeID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "ID", "MediaTypeName", pageDetails.MediaTypeID);
            ViewBag.PageID = new SelectList(db.PageInfo, "ID", "PageName", pageDetails.PageID);
            ViewBag.ParaGraphesID = new SelectList(db.ParaGraphes, "ID", "ParaGrapheName", pageDetails.ParaGraphesID);
            ViewBag.TextTypeID = new SelectList(db.textTypes, "ID", "TextTypeName", pageDetails.TextTypeID);
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "TitleName", pageDetails.TitleID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType", pageDetails.UserId);
            return View(pageDetails);
        }

        // GET: PageDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageDetails pageDetails = db.PageDetails.Find(id);
            if (pageDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentID = new SelectList(db.ContentInfo, "ID", "ContentName", pageDetails.ContentID);
            ViewBag.MediaSubTypeID = new SelectList(db.MediaSubTypes, "ID", "url", pageDetails.MediaSubTypeID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "ID", "MediaTypeName", pageDetails.MediaTypeID);
            ViewBag.PageID = new SelectList(db.PageInfo, "ID", "PageName", pageDetails.PageID);
            ViewBag.ParaGraphesID = new SelectList(db.ParaGraphes, "ID", "ParaGrapheName", pageDetails.ParaGraphesID);
            ViewBag.TextTypeID = new SelectList(db.textTypes, "ID", "TextTypeName", pageDetails.TextTypeID);
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "TitleName", pageDetails.TitleID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType", pageDetails.UserId);
            return View(pageDetails);
        }

        // POST: PageDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,MediaTypeID,PageID,ContentID,MediaSubTypeID,TextTypeID,ParaGraphesID,TitleID")] PageDetails pageDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContentID = new SelectList(db.ContentInfo, "ID", "ContentName", pageDetails.ContentID);
            ViewBag.MediaSubTypeID = new SelectList(db.MediaSubTypes, "ID", "url", pageDetails.MediaSubTypeID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "ID", "MediaTypeName", pageDetails.MediaTypeID);
            ViewBag.PageID = new SelectList(db.PageInfo, "ID", "PageName", pageDetails.PageID);
            ViewBag.ParaGraphesID = new SelectList(db.ParaGraphes, "ID", "ParaGrapheName", pageDetails.ParaGraphesID);
            ViewBag.TextTypeID = new SelectList(db.textTypes, "ID", "TextTypeName", pageDetails.TextTypeID);
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "TitleName", pageDetails.TitleID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType", pageDetails.UserId);
            return View(pageDetails);
        }

        // GET: PageDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageDetails pageDetails = db.PageDetails.Find(id);
            if (pageDetails == null)
            {
                return HttpNotFound();
            }
            return View(pageDetails);
        }

        // POST: PageDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageDetails pageDetails = db.PageDetails.Find(id);
            db.PageDetails.Remove(pageDetails);
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
        [Authorize(Roles = "admin")]

        public ActionResult MainManagement(int? id)
        {
            List<ContentInfo> contentlist = db.ContentInfo.ToList();
            ViewBag.ContentInfo = contentlist;


            List<PageInfo> pageinfolist = db.PageInfo.ToList();
            ViewBag.PageInfolist = pageinfolist;


            var pageInfo = id;
            ViewBag.PageInfo = pageInfo;

            return View(db.PageDetails.ToList());
        }
        [HttpPost]
        public JsonResult AddCon1(AdminViewModels AdminViewModels)
        {
            var TempMediaTypeID = 1;
            if ( AdminViewModels.MediaTypeID== TempMediaTypeID) {
                var pageDetails = db1.PageDetails.Where(t => t.MediaTypeID == 2).ToList ();
                
                foreach (var pageDetail in pageDetails) {
                    
                    db1.PageDetails.Remove(pageDetail);
                    db1.SaveChanges();

                }
                var mediaSubTypes = db.MediaSubTypes.Where(t => t.MediaTypeID == 2).ToList();

                foreach (var mediaSubType in mediaSubTypes)
                {
                    db.MediaSubTypes.Remove(mediaSubType);
                    db.SaveChanges();

                }
                
            }
            else
            {
                PageDetails pageDetails = db1.PageDetails.FirstOrDefault(t => t.MediaTypeID == 1);
                MediaSubTypes mediaSubTypes = db.MediaSubTypes.FirstOrDefault(t => t.MediaTypeID == 1);
                db1.PageDetails.Remove(pageDetails);
                db.MediaSubTypes.Remove(mediaSubTypes);
            }

            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            MediaSubTypes mediasubtypes = new MediaSubTypes();
            var fileN = AdminViewModels.uploadurl;
            if (fileN != null)
            {
                var filename = Path.GetFileName(fileN.FileName);
                var extension = Path.GetExtension(fileN.FileName);
                var filewithoutextension = Path.GetFileNameWithoutExtension(fileN.FileName);
                fileN.SaveAs(Server.MapPath("/UploadFiles/" + fileN.FileName));
                mediasubtypes.url = filename;
                mediasubtypes.MediaTypeID  = AdminViewModels .MediaTypeID ;
                mediasubtypes.UserId = currentUserId;

            }
            if(AdminViewModels .TitleName != null )
            {
                Titles titles = new Titles();
                titles.UserId = currentUserId;
                titles.TitleName = AdminViewModels.TitleName;
                db1.Titles.Add(titles);
                db1.SaveChanges();

            }
            if (AdminViewModels.ParaGrapheName  != null)
            {
                ParaGraphes paraGraphes   = new ParaGraphes ();
                paraGraphes .UserId = currentUserId;
                paraGraphes .ParaGrapheName  = AdminViewModels.ParaGrapheName ;
                db2.ParaGraphes .Add(paraGraphes );
                db2.SaveChanges();

            }
            if (ModelState.IsValid)
            {
                db.MediaSubTypes.Add(mediasubtypes);
                db.SaveChanges();
                int MediaSubTypeID = db.MediaSubTypes.Max(x => x.ID);
                int ParaGrapheID = db.ParaGraphes.Max(x => x.ID);
                int TitleID = db.Titles.Max(x => x.ID);

                PageDetails pageDetails = new PageDetails();
                pageDetails.MediaSubTypeID = MediaSubTypeID;
                pageDetails.UserId = currentUserId;
                pageDetails.MediaTypeID = AdminViewModels.MediaTypeID;
                pageDetails.TitleID  = TitleID;
                pageDetails.ParaGraphesID  = ParaGrapheID ;
                pageDetails.ContentID = 1;
                pageDetails.PageID  = 1;
                db3.PageDetails .Add(pageDetails);
                db3.SaveChanges();
                return Json("1");
            }

            return Json(AdminViewModels);
        }
        [HttpPost]
        public JsonResult AddCon2(AdminViewModels AdminViewModels)
        {
           
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            MediaSubTypes mediasubtypes = new MediaSubTypes();
            var fileN = AdminViewModels.uploadurl;
            if (fileN != null)
            {
                
                var filename = Path.GetFileName(fileN.FileName);
                var extension = Path.GetExtension(fileN.FileName);
                var filewithoutextension = Path.GetFileNameWithoutExtension(fileN.FileName);
                fileN.SaveAs(Server.MapPath("/UploadFiles/" + fileN.FileName));
                mediasubtypes.url = filename;
                mediasubtypes.MediaTypeID  = AdminViewModels .MediaTypeID ;
                mediasubtypes.UserId = currentUserId;

            }
            if (ModelState.IsValid)
            {
                db.MediaSubTypes.Add(mediasubtypes);
                db.SaveChanges();
                int MediaSubTypeID = db.MediaSubTypes.Max(x => x.ID);
                PageDetails pageDetails = new PageDetails();
                pageDetails.MediaSubTypeID = MediaSubTypeID;
                pageDetails.UserId = currentUserId;
                pageDetails.MediaTypeID = AdminViewModels.MediaTypeID;
                pageDetails.ContentID = 10;
                pageDetails.PageID  = Convert.ToInt32(AdminViewModels.PageID);
                db1.PageDetails .Add(pageDetails);
                db1.SaveChanges();
                return Json("1");
            }

            return Json(AdminViewModels);
        }

        [HttpPost]
        public JsonResult AddPar(AdminViewModels AdminViewModels)
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            if (AdminViewModels.TitleName != null)
            {
                Titles titles = new Titles();
                titles.UserId = currentUserId;
                titles.TitleName = AdminViewModels.TitleName;
                db1.Titles.Add(titles);
                db1.SaveChanges();

            }
            if (AdminViewModels.ParaGrapheName != null)
            {
                ParaGraphes paraGraphes = new ParaGraphes();
                paraGraphes.UserId = currentUserId;
                paraGraphes.ParaGrapheName = AdminViewModels.ParaGrapheName;
                db2.ParaGraphes.Add(paraGraphes);
                db2.SaveChanges();

            }
            if (ModelState.IsValid)
            {
                int ParaGrapheID = db.ParaGraphes.Max(x => x.ID);
                int TitleID = db.Titles.Max(x => x.ID);

                PageDetails pageDetails = new PageDetails();
                pageDetails.UserId = currentUserId;
                pageDetails.TitleID = TitleID;
                pageDetails.ParaGraphesID = ParaGrapheID;
                pageDetails.ContentID = 11;
                pageDetails.PageID = Convert.ToInt32(AdminViewModels.PageID);
                db3.PageDetails.Add(pageDetails);
                db3.SaveChanges();
                return Json("1");
            }

            return Json(AdminViewModels);
        }

        [HttpPost]
        public JsonResult UpdateN(AdminViewModels AdminViewModels)
        {
            if (ModelState.IsValid)
            {
                MediaSubTypes mediasubtypes = new MediaSubTypes();

                string oldpath = Path.Combine(Server.MapPath("~/Uploads"), AdminViewModels.url);
                var fileN = AdminViewModels.uploadurl;
                if (fileN != null)
                {
                    if (oldpath != null)
                    {
                        System.IO.File.Delete(oldpath); //مسح oldpath
                    }
                    var filename = Path.GetFileName(fileN.FileName);
                    var extension = Path.GetExtension(fileN.FileName);
                    var filewithoutextension = Path.GetFileNameWithoutExtension(fileN.FileName);
                    fileN.SaveAs(Server.MapPath("/Uploads/" + fileN.FileName));
                    mediasubtypes.ID = AdminViewModels.ID;
                    mediasubtypes.url = filename;

                }

                db.Entry(mediasubtypes).State = EntityState.Modified;
                db.SaveChanges();
                return Json("1");
            }
            return Json(AdminViewModels);
        }
       
        public JsonResult DeleteSlide(int? id)
        {
            //هنا وجب ان نركز على مسح CHILD FIRST (OrderDetails)
            PageDetails pageDetails  = db1.PageDetails.FirstOrDefault(t => t.MediaSubTypeID  == id);
            MediaSubTypes mediaSubTypes = db.MediaSubTypes.FirstOrDefault(x => x.ID == id);

            string oldpath = Path.Combine(Server.MapPath("~/UploadFiles"), mediaSubTypes.url);
            System.IO.File.Delete(oldpath);

            db.MediaSubTypes.Remove(mediaSubTypes );
            db1.PageDetails.Remove(pageDetails );
            db1.SaveChanges();
            db.SaveChanges();

            return Json("1");
        }

        public JsonResult DeleteSlideS(int? id)
        {
            //هنا وجب ان نركز على مسح CHILD FIRST (OrderDetails)
            
            foreach(var item in db.PageDetails)
            {
                if (item.MediaTypeID ==2) {
            PageDetails pageDetails = db.PageDetails.FirstOrDefault(t => t.MediaSubTypeID == item.ID);
            MediaSubTypes mediaSubTypes = db.MediaSubTypes.FirstOrDefault(t => t.ID == item.ID);

            string oldpath = Path.Combine(Server.MapPath("~/UploadFiles"), mediaSubTypes.url);
            System.IO.File.Delete(oldpath);

            db.MediaSubTypes.Remove(mediaSubTypes);
            db.PageDetails.Remove(pageDetails);
            db.SaveChanges();
                }
            }
            return Json("1");
        }
     
        public JsonResult Addtype(AdminViewModels AdminViewModels)
        {
            
          
            if (AdminViewModels.ContentName != null)
            {
                ContentInfo contentInfo = new ContentInfo();

                contentInfo.ContentName = AdminViewModels.ContentName;
                contentInfo.PageID = Convert.ToInt32(AdminViewModels.PageID);
                db1.ContentInfo.Add(contentInfo);
                db1.SaveChanges();

            }
            return Json(AdminViewModels);
        }
        public JsonResult AddPage(AdminViewModels AdminViewModels)
        {
            if (AdminViewModels.PageName != null)
            {
                PageInfo pageInfo = new PageInfo();

                pageInfo.PageName = AdminViewModels.PageName;
                pageInfo.PageAName = AdminViewModels.PageAName;
                pageInfo.PageEName = AdminViewModels.PageEName;
                db.PageInfo.Add(pageInfo);
                db.SaveChanges();

            }
            return Json(AdminViewModels);
        }
    }
}

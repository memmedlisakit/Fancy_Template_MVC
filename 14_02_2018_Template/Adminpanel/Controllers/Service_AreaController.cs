using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _14_02_2018_Template.Models;
using System.IO;
using _14_02_2018_Template.App_Start;

namespace _14_02_2018_Template.Adminpanel.Controllers
{
    [Admin_Filter]
    public class Service_AreaController : Controller
    {
        private FancyEntities db = new FancyEntities();

        // GET: Service_Area
        public ActionResult Index()
        {
            return View(db.Service_Area.ToList());
        }

        // GET: Service_Area/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Area service_Area = db.Service_Area.Find(id);
            if (service_Area == null)
            {
                return HttpNotFound();
            }
            return View(service_Area);
        }

        // GET: Service_Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service_Area/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "service_id,service_title,service_content,service_content_url")] Service_Area service_Area, HttpPostedFileBase service_img)
        {
            if (ModelState.IsValid)
            {
                string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(service_img.FileName);
                string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                service_img.SaveAs(file_path);
                service_Area.service_img = file_name;

                db.Service_Area.Add(service_Area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service_Area);
        }

        // GET: Service_Area/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Area service_Area = db.Service_Area.Find(id);
            if (service_Area == null)
            {
                return HttpNotFound();
            }
            return View(service_Area);
        }

        // POST: Service_Area/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "service_id,service_title,service_content,service_content_url")] Service_Area service_Area, HttpPostedFileBase service_img)
        {
            Service_Area selected = db.Service_Area.Find(service_Area.service_id);
            if (ModelState.IsValid)
            {
                if (service_img != null)
                {
                    string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(service_img.FileName);
                    string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                    service_img.SaveAs(file_path);
                    selected.service_img = file_name;
                }


                selected.service_title = service_Area.service_title;
                selected.service_content = service_Area.service_content;
                selected.service_content_url = service_Area.service_content_url;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_Area);
        }

        // GET: Service_Area/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Area service_Area = db.Service_Area.Find(id);
            if (service_Area == null)
            {
                return HttpNotFound();
            }
            return View(service_Area);
        }

        // POST: Service_Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_Area service_Area = db.Service_Area.Find(id);
            db.Service_Area.Remove(service_Area);
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

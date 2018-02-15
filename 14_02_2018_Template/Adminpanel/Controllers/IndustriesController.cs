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
    public class IndustriesController : Controller
    {
        private FancyEntities db = new FancyEntities();

        // GET: Industries
        public ActionResult Index()
        {
            return View(db.Industries.ToList());
        }

        // GET: Industries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // GET: Industries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Industries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "industries_id,industries_title,industries_content,industries_url")] Industry industry, HttpPostedFileBase industries_img)
        {
            if (ModelState.IsValid)
            {
                string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(industries_img.FileName);
                string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                industries_img.SaveAs(file_path);
                industry.industries_img = file_name;


                db.Industries.Add(industry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(industry);
        }

        // GET: Industries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // POST: Industries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "industries_id,industries_title,industries_content,industries_url")] Industry industry, HttpPostedFileBase industries_img)
        {
            Industry selected = db.Industries.Find(industry.industries_id);
            if (ModelState.IsValid)
            {

                    if (industries_img != null)
                    {
                        string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(industries_img.FileName);
                        string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                        industries_img.SaveAs(file_path);
                        selected.industries_img = file_name;
                    }

                selected.industries_title = industry.industries_title;
                selected.industries_content = industry.industries_content;
                selected.industries_url = industry.industries_url;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(industry);
        }

        // GET: Industries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // POST: Industries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Industry industry = db.Industries.Find(id);
            db.Industries.Remove(industry);
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

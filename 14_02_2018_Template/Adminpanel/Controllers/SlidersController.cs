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
    public class SlidersController : Controller
    {
        private FancyEntities db = new FancyEntities();


        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "slider_id,slider_title,slider_first_url,slider_second_url")] Slider slider, HttpPostedFileBase slider_img)
        {
            if (ModelState.IsValid)
            {
                string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(slider_img.FileName);
                string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                slider_img.SaveAs(file_path);
                slider.slider_img = file_name;

                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "slider_id,slider_title,slider_first_url,slider_second_url")] Slider slider, HttpPostedFileBase slider_img)
        {
            Slider selected = db.Sliders.Find(slider.slider_id);

            if (ModelState.IsValid)
            {
                if (slider_img != null)
                {
                    string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(slider_img.FileName);
                    string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                    slider_img.SaveAs(file_path);
                    selected.slider_img = file_name;
                }

                selected.slider_title = slider.slider_title;
                selected.slider_first_url = slider.slider_first_url;
                selected.slider_second_url = slider.slider_second_url;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
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

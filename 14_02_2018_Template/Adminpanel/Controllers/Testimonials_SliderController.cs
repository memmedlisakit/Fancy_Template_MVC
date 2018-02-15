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
    public class Testimonials_SliderController : Controller
    {
        private FancyEntities db = new FancyEntities();

        // GET: Testimonials_Slider
        public ActionResult Index() 
        {
            return View(db.Testimonials_Slider.ToList());
        }

        // GET: Testimonials_Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            if (testimonials_Slider == null)
            {
                return HttpNotFound();
            }
            return View(testimonials_Slider);
        }

        // GET: Testimonials_Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testimonials_Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "testimonials_slider_id,testimonials_slider_icon,testimonials_slider_content,testimonials_slider_author,testimonials_slider_position")] Testimonials_Slider testimonials_Slider, HttpPostedFileBase testimonials_slider_img)
        {
            if (ModelState.IsValid)
            {
                string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(testimonials_slider_img.FileName);
                string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                testimonials_slider_img.SaveAs(file_path);
                testimonials_Slider.testimonials_slider_img = file_name;

                db.Testimonials_Slider.Add(testimonials_Slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testimonials_Slider);
        }

        // GET: Testimonials_Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            if (testimonials_Slider == null)
            {
                return HttpNotFound();
            }
            return View(testimonials_Slider);
        }

        // POST: Testimonials_Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "testimonials_slider_id,testimonials_slider_icon,testimonials_slider_content,testimonials_slider_author,testimonials_slider_position")] Testimonials_Slider testimonials_Slider, HttpPostedFileBase testimonials_slider_img)
        {
            Testimonials_Slider selected = db.Testimonials_Slider.Find(testimonials_Slider.testimonials_slider_id);

            if (ModelState.IsValid)
            {
                if (testimonials_slider_img != null)
                {
                    string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(testimonials_slider_img.FileName);
                    string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                    testimonials_slider_img.SaveAs(file_path);
                    selected.testimonials_slider_img = file_name;
                }

                selected.testimonials_slider_icon = testimonials_Slider.testimonials_slider_icon;
                selected.testimonials_slider_content = testimonials_Slider.testimonials_slider_content;
                selected.testimonials_slider_author = testimonials_Slider.testimonials_slider_author;
                selected.testimonials_slider_position = testimonials_Slider.testimonials_slider_position;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonials_Slider);
        }

        // GET: Testimonials_Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            if (testimonials_Slider == null)
            {
                return HttpNotFound();
            }
            return View(testimonials_Slider);
        }

        // POST: Testimonials_Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            db.Testimonials_Slider.Remove(testimonials_Slider);
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

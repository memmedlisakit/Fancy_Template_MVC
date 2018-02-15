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
    public class BlogsController : Controller
    {
        private FancyEntities db = new FancyEntities();

        
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category);
            return View(blogs.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "blog_id,blog_title,blog_content,blog_category_id")] Blog blog, HttpPostedFileBase blog_img)
        {
            
            if (ModelState.IsValid)
            {
                string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(blog_img.FileName);
                string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                blog_img.SaveAs(file_path);
                blog.blog_img = file_name;

                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name", blog.blog_category_id);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name", blog.blog_category_id);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "blog_id,blog_title,blog_content,blog_category_id")] Blog blog, HttpPostedFileBase blog_img)
        {
            Blog selected = db.Blogs.Find(blog.blog_id);

            if (ModelState.IsValid)
            {
                if (blog_img != null)
                {
                    string file_name = DateTime.Now.ToString("MMddyyyyfffttHHssmm") + Path.GetFileName(blog_img.FileName);
                    string file_path = Path.Combine(Server.MapPath("~/Uploads/"), file_name);
                    blog_img.SaveAs(file_path);
                    selected.blog_img = file_name;
                }

                selected.blog_title = blog.blog_title;
                selected.blog_content = blog.blog_content;
                selected.blog_category_id = blog.blog_category_id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name", blog.blog_category_id);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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

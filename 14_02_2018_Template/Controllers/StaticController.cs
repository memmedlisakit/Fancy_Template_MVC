using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _14_02_2018_Template.Models;

namespace _14_02_2018_Template.Controllers
{
    public class StaticController : Controller
    {
        FancyEntities db = new FancyEntities();
        public ActionResult Index(int? id)
        {
            return View(db.Blogs.Find(id));
        }
    }
}
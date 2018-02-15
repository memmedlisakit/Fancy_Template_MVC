using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _14_02_2018_Template.Models;

namespace _14_02_2018_Template.Controllers
{
    public class HomeController : Controller
    {
        FancyEntities db = new FancyEntities();
        public ActionResult Index()
        { 
            return View(new ViewModel() {
                _boxs = db.Feature_Boxes.ToList(),
                _blogs = db.Blogs.OrderByDescending(b=>b.blog_id).Take(4).ToList(),
                _industry = db.Industries.First(),
                _service_area = db.Service_Area.ToList(),
                _contents = db.Service_Area_Contents.ToList(),
               _testimintial_slider = db.Testimonials_Slider.ToList(),
            });
        }
    }
}
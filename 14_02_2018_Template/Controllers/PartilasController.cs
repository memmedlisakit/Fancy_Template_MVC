using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _14_02_2018_Template.Models;
using System.Web.Mvc;

namespace _14_02_2018_Template.Controllers
{
    public class PartilasController : Controller
    {
        FancyEntities db = new FancyEntities();
      
        public PartialViewResult Top_menu()
        {
            return PartialView(db.Menus.ToList());
        }

        public PartialViewResult Footer()
        { 
            return PartialView(new FooterViewModel() { _categories = db.Categories.ToList(), _contact=db.Contacts.First() });
        }

        public PartialViewResult Slider()
        {
            return PartialView(db.Sliders.ToList());
        }
         
        public PartialViewResult Static_right_side()
        {
                return PartialView(new Blog_Category_ViewModel() {
                    _categories = db.Categories.ToList(),
                    _blogs = db.Blogs.OrderBy(b => b.blog_id).Take(5).ToList(),
                });  
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _14_02_2018_Template.Models;

namespace _14_02_2018_Template.Controllers
{
    public class ContactUsController : Controller
    {
        FancyEntities db = new FancyEntities();
        public ActionResult Index()
        {

            return View(db.Contacts.First());
        }

        [HttpPost]
        public ActionResult Message(FormCollection form)
        {
            db.Messages.Add(new Message()
            {
                message_name = form["message_name"],
                message_email = form["message_email"],
                message_website_url = form["message_website_url"],
                message_content = form["message_content"]
            });
            db.SaveChanges();
            TempData["message"] = "Your message sent. Contact with you soon.";
            return RedirectToAction("Index");
        }
    }
}
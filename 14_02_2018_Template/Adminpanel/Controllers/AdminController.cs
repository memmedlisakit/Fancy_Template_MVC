using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _14_02_2018_Template.Adminpanel.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Check_Session())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            Session["email"] = form["email"];
            Session["password"] = form["password"];
            if (Check_Session())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Session["email"] = null;
            Session["password"] = null;
            return RedirectToAction("Login");
        }


        private bool Check_Session()
        {
            if  (Session["email"] != null && Session["password"] != null) 
            {
                if (Session["email"].ToString() == "admin" && Session["password"].ToString() == "123")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _14_02_2018_Template.App_Start
{
    public class Admin_Filter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["email"] == null|| HttpContext.Current.Session["password"] ==null)
            {
                filterContext.Result = new RedirectResult("~/Admin/Login");
                return;
            }
            else
            {
                if (HttpContext.Current.Session["email"].ToString() != "admin" && HttpContext.Current.Session["password"].ToString() != "123")
                {
                    filterContext.Result = new RedirectResult("~/Admin/Login");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
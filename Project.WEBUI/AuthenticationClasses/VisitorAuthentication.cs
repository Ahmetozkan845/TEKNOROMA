using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.AuthenticationClasses
{
    public class VisitorAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["guest"] != null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Shopping/ShoppingList");
            return false;
        }
    }
}
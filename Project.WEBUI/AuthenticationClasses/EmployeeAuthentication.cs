using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.AuthenticationClasses
{
    public class EmployeeAuthentication:AuthorizeAttribute
    {
        //Geçersiz tüm istekleri ShoppingList e yönlendirdim
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["manager"] != null || 
                httpContext.Session["sale"] != null || 
                httpContext.Session["ware"] != null || 
                httpContext.Session["acc"] != null || 
                httpContext.Session["tech"] != null || 
                httpContext.Session["mobile"] != null)
            {
                return true;
            }
            //Response => yanıt, karşılık 
            //Redirect => Yönlendir

            httpContext.Response.Redirect("/Shopping/ShoppingList");
            return false;

        }
    }
}
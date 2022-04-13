using System.Web.Mvc;

namespace Project.WEBUI.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_default",


                "Administration/{controller}/{action}/{id}",

                //Index e git Id = Url içinde opsiyonel 
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
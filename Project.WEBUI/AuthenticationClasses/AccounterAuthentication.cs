using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.AuthenticationClasses
{
    //Yetkilendirme İşlemleri 
    //Accounter = Muhasebe Departmanı
    //Session(Oturum) Kaynak => 28 Aralık Mvc Dersi Filters Kodları Deneme
    //Session server taraflı veri saklar Cookie client taraflı veri saklar
    //Yapı prensibi şöyle ki  giriş yapacak kullanıcı Id Şifre doğru ise giriş yap değilse Shopping List e yönlendir


    //örnek kod
    //public void OnAuthorization(AuthorizationContext filterContext)
    //{
    //    if (filterContext.HttpContext.Session["login"] == null)
    //    {

    //        filterContext.Controller.TempData["Error"] = "bu alanı görüntülemeye yetkiniz bulunmamaktadır!";
    //filterContext.Result = new RedirectResult("~/Home/Login");

    //HttpContext serverla haberleşme API de detaylı incelendi
    // ! = null => Boş Değilse
    // Mantıksal operatörlerden || kullandım ki herhangi biri doğruysa işleme devam edebilsin, diğer Authenticationlarda da bu ve benzeri kullanacağım
}
public class AccounterAuthentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["accounter"] != null || httpContext.Session["manager"] != null)
            {
                return true;
            }


            httpContext.Response.Redirect("/Shopping/ShoppingList");
            return false;
        }
    }

using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        
        AppUserRepository _apRep;
        public LoginController()
        {
            _apRep = new AppUserRepository();
        }
        // kaynak => miro.medium.com/max/1252/1*P0j3e-3JvqlTXnrHwtpZfA.png
        // Login ayarlarını burada yap.
        //Projede Belirtilen kişileri burada tanıt ?
        //md5 kriptografi incele
        //Encyrpt Decrypt Kriptografi Ayarlarını incele ????
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            AppUser user = _apRep.FirstOrDefault(x => x.UserName == appUser.UserName);

            if (user == null)
            {
                ViewBag.KullaniciYok = "Kullanıcı bulunamadı";
                return View();
            }

            string decrypted = PasswordHasher.DeCrypt(user.Password);

            if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.Admin)
            {
                Session["admin"] = user;
                return RedirectToAction("AppUserList", "AppUser", new { Area = "Administration" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.BranchManager)
            {
                Session["manager"] = user;
                return RedirectToAction("AppUserList", "AppUser", new { Area = "Administration" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.SalesRepresentative)
            {
                Session["sale"] = user;
                return RedirectToAction("ProductList", "Product", new { Area = "Administration" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.WarehouseRepresentative)
            {
                Session["ware"] = user;
                return RedirectToAction("ProductList", "Product", new { Area = "Administration" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.AccountingRepresentative)
            {
                Session["accounter"] = user;
                return RedirectToAction("ExpenseList", "Expense", new { Area = "Administration" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.TechnicalServiceRepresentative)
            {
                Session["tech"] = user;
                return RedirectToAction("IssueList", "Issue", new { Area = "Administration" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.MobileSalesRepresentative)
            {
                Session["mobileSale"] = user;
                return RedirectToAction("ProductList", "Product", new { Area = "Administration" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.Member)
            {
                if (!user.Active)
                {
                    return AktifKontrol();
                }
                Session["member"] = user;
                return RedirectToAction("ShoppingList", "Shopping");
            }

            ViewBag.KullaniciYok = "Kullanıcı bulunamadı";
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        private ActionResult AktifKontrol()
        {
            ViewBag.AktifDegil = "Hesabınız aktif değil. Lütfen emailinizi kontrol ediniz.";
            return View("Login");
        }
    }
}
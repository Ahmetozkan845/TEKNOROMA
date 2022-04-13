using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WEBUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class RegisterController : Controller
    {

        AppUserRepository _apRep;
        UserProfileRepository _proRep;

        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _proRep = new UserProfileRepository();
        }

        // GET: Register
        public ActionResult RegisterNow()
        {
            return View();
        }
        //Kriptografi deneme
        [HttpPost]
        public ActionResult RegisterNow(AppUserVM apvm)
        {
            AppUser user = apvm.AppUser;
            UserProfile profile = apvm.Profile;

            user.Password = PasswordHasher.Crypt(user.Password);
            user.ConfirmPassword = PasswordHasher.Crypt(user.ConfirmPassword);

            if (_apRep.Any(x => x.UserName == user.UserName))
            {
                ViewBag.KullaniciVar = "kullanıcı ismi daha önce alınmış.Lütfen yeni bir kullanıcı adı giriniz.";
                return View();
            }
            else if (_apRep.Any(x => x.Email == user.Email))
            {
                ViewBag.KullaniciVar = "E-mail daha önceden kullanılmış. Lütfen yeni bir email giriniz.";
                return View();
            }

            //Başarılı register'da mail gönderme

            string aktivasyonMail = "Tebrikler! Hesabınız başarıyla oluşturuldu. Hesabınızı aktifleştirmek için  https://localhost:44335/Register/Activation/" + user.ActivationCode + " linkine tıklayabilirsiniz.";

            MailService.Send(user.Email, body: aktivasyonMail, subject: "TEKNOROMA'ya Hoşgeldiniz!");

            _apRep.Add(user);
            //Profile eklemek için önce AppUser ekleyip ID'si oluşturulması gerekmektedir.

            if (!string.IsNullOrEmpty(profile.FirstName) || !string.IsNullOrEmpty(profile.LastName) || !string.IsNullOrEmpty(profile.Address) || !string.IsNullOrEmpty(profile.TCNO))
            {
                profile.ID = user.ID;
                _proRep.Add(profile);
            }

            return View("RegisterOk");

        }

        public ActionResult Activation(Guid id)
        {
            AppUser aktifEdilecek = _apRep.FirstOrDefault(x => x.ActivationCode == id);

            if (aktifEdilecek != null)
            {
                aktifEdilecek.Active = true;
                _apRep.Update(aktifEdilecek);
                TempData["HesapAktif"] = "Hesabınız aktif hale getirilmiştir. Mutlu günlerde Kullanma Dileğiyle...";
                return RedirectToAction("Login", "Login");
            }
            TempData["HesapAktif"] = "Hesap bulunamadı.";
            return RedirectToAction("Login", "Login");
        }

        public ActionResult RegisterOk()
        {
            return View();
        }
    }
}
using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WEBUI.AuthenticationClasses;
using Project.WEBUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Administration.Controllers
{
    [AdminAuthentication]
    public class AppUserController : Controller
    {
        // GET: Administration/AppUser
        AppUserRepository _aRep;

        public AppUserController()
        {
            _aRep = new AppUserRepository();
        }

        public ActionResult AppUserList(int? id)
        {
            AppUserVM svm = id == null ? new AppUserVM
            {
                AppUsers = _aRep.GetActives()
            } : new AppUserVM { AppUsers = _aRep.Where(x => x.ID == id) };
            return View(svm);
        }

        public ActionResult AddAppUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAppUser(AppUser appuser)
        {
            appuser.Active = true;
            _aRep.Add(appuser);
            return RedirectToAction("AppUserList");
        }

        public ActionResult UpdateAppUser(int id)
        {
            AppUserVM svm = new AppUserVM
            {
                AppUser = _aRep.Find(id)
            };
            return View(svm);
        }

        [HttpPost]
        public ActionResult UpdateAppUser(AppUser appuser)
        {
            appuser.Active = true;
            _aRep.Update(appuser);
            return RedirectToAction("AppUserList");
        }

        public ActionResult DeleteAppUser(int id)
        {
            _aRep.Destroy(_aRep.Find(id));
            return RedirectToAction("AppUserList");
        }
    }
}
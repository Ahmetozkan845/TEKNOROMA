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
    [TechServiceAuthentication]
    public class IssueController : Controller
    {
        // GET: Administration/Issue
        IssueRepository _iRep;
        AppUserRepository _aRep;

        public IssueController()
        {
            _iRep = new IssueRepository();
            _aRep = new AppUserRepository();
        }

        // GET: Administration/Category
        public ActionResult IssueList(int? id)
        {
            IssueVM ivm = new IssueVM
            {
                Issues = id == null ? _iRep.GetActives() : _iRep.Where(x => x.AppUserID == id)
            };
            return View(ivm);
        }

        public ActionResult AddIssue()
        {
            IssueVM ivm = new IssueVM
            {
                Issue = new Issue(),
                AppUsers = _aRep.GetActives()
            };
            return View(ivm);
        }

        [HttpPost]
        public ActionResult AddIssue(Issue issue)
        {
            _iRep.Add(issue);
            return RedirectToAction("IssueList");
        }

        public ActionResult UpdateIssue(int id)
        {
            IssueVM ivm = new IssueVM
            {
                Issue = _iRep.Find(id),
                AppUsers = _aRep.GetActives()
            };
            return View(ivm);
        }

        [HttpPost]
        public ActionResult UpdateIssue(Issue issue)
        {
            _iRep.Update(issue);
            return RedirectToAction("IssueList");
        }

        public ActionResult DeleteIssue(int id)
        {
            _iRep.Delete(_iRep.Find(id));
            return RedirectToAction("IssueList");
        }
    }
}
using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WEBUI.AuthenticationClasses;
using Project.WEBUI.Models.Helpers;
using Project.WEBUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Administration.Controllers
{
    [AccounterAuthentication]
    [ManagerAuthentication]
    public class ExpenseController : Controller
    {
        
        ExpenseRepository _eRep;

        public ExpenseController()
        {
            _eRep = new ExpenseRepository();
        }

        // GET: Administration/Category
        public ActionResult ExpenseList(int? id)
        {
            ExpenseVM evm = id == null ? new ExpenseVM
            {
                Expenses = _eRep.GetActives()
            } : new ExpenseVM { Expenses = _eRep.Where(x => x.ID == id) };

            Currency c = new Currency();
            ViewBag.EuroSell = c.EuroSell;
            ViewBag.EuroBuy = c.EuroBuy;
            ViewBag.DolarSell = c.DolarSell;
            ViewBag.DolarBuy = c.DolarBuy;

            return View(evm);
        }

        public ActionResult AddExpense()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExpense(Expense expense)
        {
            _eRep.Add(expense);
            return RedirectToAction("ExpenseList");
        }

        public ActionResult UpdateExpense(int id)
        {
            ExpenseVM evm = new ExpenseVM
            {
                Expense = _eRep.Find(id)
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult UpdateExpense(Expense expense)
        {
            _eRep.Update(expense);
            return RedirectToAction("ExpenseList");
        }

        public ActionResult DeleteExpense(int id)
        {
            _eRep.Delete(_eRep.Find(id));
            return RedirectToAction("ExpenseList");
        }
    }
}
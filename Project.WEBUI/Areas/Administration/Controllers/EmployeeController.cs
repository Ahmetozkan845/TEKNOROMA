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
    
    [ManagerAuthentication]
    public class EmployeeController : Controller
    {
        // GET: Administration/Employee
        EmployeeRepository _eRep;

        public EmployeeController()
        {
            _eRep = new EmployeeRepository();
        }

        // GET: Administration/Category
        public ActionResult EmployeeList(int? id)
        {
            EmployeeVM evm = id == null ? new EmployeeVM
            {
                Employees = _eRep.GetActives()
            } : new EmployeeVM { Employees = _eRep.Where(x => x.ID == id) };
            return View(evm);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            _eRep.Add(employee);
            return RedirectToAction("EmployeeList");
        }

        public ActionResult UpdateEmployee(int id)
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employee = _eRep.Find(id)
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            _eRep.Update(employee);
            return RedirectToAction("EmployeeList");
        }

        public ActionResult DeleteEmployee(int id)
        {
            _eRep.Delete(_eRep.Find(id));
            return RedirectToAction("EmployeeList");
        }
    }
}
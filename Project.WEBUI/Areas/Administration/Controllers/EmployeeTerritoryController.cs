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
    public class EmployeeTerritoryController : Controller
    {
        EmployeeRepository _eRep;
        TerritoryRepository _tRep;
        EmployeeTerritoryRepository _etRep;

        public EmployeeTerritoryController()
        {
            _etRep = new EmployeeTerritoryRepository();
            _eRep = new EmployeeRepository();
            _tRep = new TerritoryRepository();
        }

        // GET: Administration/EmployeeTerritory
        public ActionResult EmployeeTerritoryList()
        {
            EmployeeTerritoryVM etvm = new EmployeeTerritoryVM
            {
                EmployeeTerritories = _etRep.GetActives()
            };
            return View(etvm);
        }

        public ActionResult AddEmployeeTerritory()
        {
            EmployeeTerritoryVM etvm = new EmployeeTerritoryVM
            {
                EmployeeTerritory = new EmployeeTerritory(),
                Territories = _tRep.GetActives(),
                Employees = _eRep.GetActives()
            };
            return View(etvm);
        }

        [HttpPost]
        public ActionResult AddEmployeeTerritory(EmployeeTerritory employeeTerritory)
        {
            _etRep.Add(employeeTerritory);
            return RedirectToAction("EmployeeTerritoryList");
        }

        

    }
}
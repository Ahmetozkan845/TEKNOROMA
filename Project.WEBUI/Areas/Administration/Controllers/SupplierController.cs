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
    [WareAuthentication]
    public class SupplierController : Controller
    {
        // GET: Administration/Supplier
        SupplierRepository _sRep;

        public SupplierController()
        {
            _sRep = new SupplierRepository();
        }

        public ActionResult SupplierList(int? id)
        {
            SupplierVM svm = id == null ? new SupplierVM
            {
                Suppliers = _sRep.GetActives()
            } : new SupplierVM { Suppliers = _sRep.Where(x => x.ID == id) };
            return View(svm);
        }

        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            _sRep.Add(supplier);
            return RedirectToAction("SupplierList");
        }

        public ActionResult UpdateSupplier(int id)
        {
            SupplierVM svm = new SupplierVM
            {
                Supplier = _sRep.Find(id)
            };
            return View(svm);
        }

        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            _sRep.Update(supplier);
            return RedirectToAction("SupplierList");
        }

        public ActionResult DeleteSupplier(int id)
        {
            _sRep.Delete(_sRep.Find(id));
            return RedirectToAction("SupplierList");
        }
    }
}
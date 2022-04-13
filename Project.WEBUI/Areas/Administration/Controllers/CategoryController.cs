﻿using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
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
    public class CategoryController : Controller
    {

        CategoryRepository _cRep;

        public CategoryController()
        {
            _cRep = new CategoryRepository();
        }

        // GET: Administration/Category
        public ActionResult CategoryList(int? id)
        {
            CategoryVM cvm = id == null ? new CategoryVM
            {
                Categories = _cRep.GetActives()
            } : new CategoryVM { Categories = _cRep.Where(x => x.ID == id) };
            return View(cvm);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _cRep.Add(category);
            return RedirectToAction("CategoryList");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = _cRep.Find(id)
            };
            return View(cvm);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _cRep.Update(category);
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            _cRep.Delete(_cRep.Find(id));
            return RedirectToAction("CategoryList");
        }
    }
}
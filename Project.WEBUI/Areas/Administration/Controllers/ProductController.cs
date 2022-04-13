using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
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
    [ManagerAuthentication, WareAuthentication, SaleAuthentication]
    public class ProductController : Controller
    {

        ProductRepository _pRep;
        CategoryRepository _cRep;
        SupplierRepository _sRep;

        public ProductController()
        {
            _pRep = new ProductRepository();
            _cRep = new CategoryRepository();
            _sRep = new SupplierRepository();
        }

        // GET: Administration/Product
        public ActionResult ProductDetail(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Products = _pRep.Where(x => x.ID == id)
            };
            return View(pvm);
        }

        public ActionResult ProductList(int? id)
        {
            ProductVM pvm = new ProductVM
            {
                Products = id == null ? _pRep.GetActives() : _pRep.Where(x => x.CategoryID == id)
            };

            Currency c = new Currency();
            ViewBag.EuroSell = c.EuroSell;
            ViewBag.EuroBuy = c.EuroBuy;
            ViewBag.DolarSell = c.DolarSell;
            ViewBag.DolarBuy = c.DolarBuy;
            return View(pvm);
        }

        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Product = new Product(),
                Categories = _cRep.GetActives(),
                Suppliers = _sRep.GetActives()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase resim)
        {
            product.ImagePath = ImageUploader.UploadImage("/Pictures/", resim);
            _pRep.Add(product);
            return RedirectToAction("ProductList");
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Categories = _cRep.GetActives(),
                Suppliers = _sRep.GetActives(),
                Product = _pRep.Find(id)
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product, HttpPostedFileBase resim)
        {
            //if (deleteImg == "true")
            //{
            //    product.ImagePath = "3";
            //}

            if (resim == null)
            {
                Product tempProduct = _pRep.Find(product.ID);
                product.ImagePath = tempProduct.ImagePath;

            }
            else
            {
                product.ImagePath = ImageUploader.UploadImage("/Pictures/", resim);
            }


            _pRep.Update(product);
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            _pRep.Delete(_pRep.Find(id));
            return RedirectToAction("ProductList");
        }
    }
}
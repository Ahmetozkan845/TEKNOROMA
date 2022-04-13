using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
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
    public class OrderController : Controller
    {
        OrderRepository _oRep;
        AppUserRepository _aRep;
        ShipperRepository _sRep;

        public OrderController()
        {
            _oRep = new OrderRepository();
            _aRep = new AppUserRepository();
            _sRep = new ShipperRepository();
        }

        // GET: Administration/Order
        public ActionResult OrderList(int? id)
        {
            OrderVM ovm = id == null ? new OrderVM
            {
                Orders = _oRep.GetActives()
            } : new OrderVM { Orders = _oRep.Where(x => x.ID == id) };
            return View(ovm);
        }
    }
}
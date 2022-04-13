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
    public class OrderDetailController : Controller
    {
        OrderDetailRepository _odRep;

        public OrderDetailController()
        {
            _odRep = new OrderDetailRepository();
        }

        // GET: Administration/OrderDetail
        public ActionResult OrderDetailList()
        {
            OrderDetailVM odvm = new OrderDetailVM
            {
                OrderDetails = _odRep.GetActives()
            };
            return View(odvm);
        }
    }
}
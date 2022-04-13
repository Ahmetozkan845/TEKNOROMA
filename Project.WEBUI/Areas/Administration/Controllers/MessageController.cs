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
    public class MessageController : Controller
    {
        MessageRepository _mRep;

        public MessageController()
        {
            _mRep = new MessageRepository();
        }

        // GET: Administration/Message
        public ActionResult MessageList(int? id)
        {
            MessageVM mvm = id == null ? new MessageVM
            {
                Messages = _mRep.GetActives()
            } : new MessageVM { Messages = _mRep.Where(x => x.ID == id) };
            return View(mvm);
        }
    }
}
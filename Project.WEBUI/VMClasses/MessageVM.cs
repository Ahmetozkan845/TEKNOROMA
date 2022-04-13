using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.VMClasses
{
    public class MessageVM
    {
        public Message Message { get; set; }
        public List<Message> Messages { get; set; }
    }
}
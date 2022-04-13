﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.VMClasses
{
    public class ShipperVM
    {
        public Shipper Shipper { get; set; }
        public List<Shipper> Shippers { get; set; }
        public List<Order> Orders { get; set; }

    }
}
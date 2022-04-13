using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum UserRole
    {
        Admin = 1,
        [Display(Name = "Genel Müdür")]
        BranchManager = 2,
        [Display(Name = "Satış Temsilcisi")]
        SalesRepresentative = 3,
        [Display(Name = "Depo Temsilcisi")]
        WarehouseRepresentative = 4,
        [Display(Name = "Muhasebe")]
        AccountingRepresentative = 5,
        [Display(Name = "Teknik Servis")]
        TechnicalServiceRepresentative = 6,
        [Display(Name = "Mobil Satış")]
        MobileSalesRepresentative = 7,
        Member = 8,
        Visitor = 9,
        Employee = 10
    }
}

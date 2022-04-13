using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum IssueStatus
    {
        [Display(Name = "Açık")]
        Open = 1,
        [Display(Name = "Kontrol Ediliyor")]
        Checking = 2,
        [Display(Name = "Kapandı")]
        Closed = 3
    }
}

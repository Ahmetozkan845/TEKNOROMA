using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum MessageType
    {
        [Display(Name = "Satıcı olmak istiyorum")]
        Sale = 1,


        [Display(Name = "Teknoroma iş ortağı olmak istiyorum")]
        Partnership = 2,



        [Display(Name = "Aldığım hizmetler hakkında yorum yapmak istiyorum")]
        Advice = 3
    }
}

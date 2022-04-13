using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Sipariş Oluşturuldu")]
        Created = 1,
        [Display(Name = "Sipariş Hazırlanıyor")]
        OrderBeingPrepared = 2,
        [Display(Name = "Sipariş Tamamlandı")]
        Completed = 3
    }
}

using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Message : BaseEntity
    {
        public Message()
        {
            MessageDate = DateTime.Now;
        }

        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Mesaj")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Girdiğiniz Email standart formatlara uymamaktadır.")]
        public string Email { get; set; }
        public DateTime MessageDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Yardım alacağınız konuyu seçiniz")]
        public MessageType MessageType { get; set; }

    }
}

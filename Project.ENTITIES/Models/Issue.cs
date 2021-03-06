using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Issue : BaseEntity
    {
        public Issue()
        {
            IssueStatus = IssueStatus.Open;
            OpenDate = DateTime.Now;
        }

        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Mesaj")]
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public DateTime OpenDate { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Girdiğiniz Email standart formatlara uymamaktadır.")]
        public string Email { get; set; }
        public int? AppUserID { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }

    }
}

using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUser : BaseEntity
    {
        public AppUser()
        {
            //UserRole Entity içindeki UserRole kullanacak

            Role = UserRole.Member;
            //member entity içerisindeki enumda tanımlı yönlendirici
            //Aktivasyon kodu ile guid tanımlanacak 

            ActivationCode = Guid.NewGuid();
        }

        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Display(Name = "Kullanıcı Adı")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Girdiğiniz kullanıcı adı standart formatlara uymamaktadır.")]
        [MinLength(3, ErrorMessage = "{0} minimum {1} karakter olabilir.")]
        [MaxLength(25, ErrorMessage = "{0} maksimum {1} karakter olabilir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Display(Name = "Parola")]
        [MinLength(5, ErrorMessage = "{0} minimum {1} karakter olabilir.")]
        [MaxLength(20, ErrorMessage = "{0} maksimum {1} karakter olabilir.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Parola Onay")]
        [Compare("Password", ErrorMessage = "Girdiğiniz parolalar uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [Display(Name = "Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Girdiğiniz Email standart formatlara uymamaktadır.")]
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public Guid ActivationCode { get; set; }
        public bool Active { get; set; }



        //Relational Properties
        public virtual UserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Issue> Issues { get; set; }



    }
}

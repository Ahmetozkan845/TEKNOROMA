using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class UserProfile:BaseEntity
    {
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TCNO { get; set; }
        public short? Age { get; set; }
        public string ImagePath { get; set; }
        public Gender? Gender { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}

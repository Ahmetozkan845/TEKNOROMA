using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO.Models
{
    public class PaymentDTO
    {
        //Sanal Post Entegrasyonu
        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal ShoppingPrice { get; set; }
    }
}

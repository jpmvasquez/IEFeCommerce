using TesteClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteClient.Models.Commands
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public string userId { get; set; }
        [ForeignKey(nameof(userId))]
        public ApplicationUser user { get; set; }

        public List<OrderDetails> orderItems { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime orderDate { get; set; }

        public int addressId { get; set; }
        public Adresse address { get; set; }

        public decimal totalPrice { get; set; }


        //public string reference => string.Format($"{userId.Substring(5)}{orderDate.ToString()}{id.ToString()}");
    }
}

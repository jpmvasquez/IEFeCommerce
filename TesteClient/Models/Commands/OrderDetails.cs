using TesteClient.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteClient.Models.Commands
{
    public class OrderDetails
    {
        [Key]
        public int id { get; set; }

        public int qty { get; set; }
        public decimal price { get; set; }

        public int productId { get; set; }
        [ForeignKey("productId")]
        public Product? product { get; set; }

        public int orderId { get; set; }
        [ForeignKey("orderId")]
        public Order? order { get; set; }
    }
}

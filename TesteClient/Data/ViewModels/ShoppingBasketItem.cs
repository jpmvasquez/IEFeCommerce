using TesteClient.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteClient.Data.ViewModels
{
    public class ShoppingBasketItem
    {
        //public int id { get; set; }

        public Product product { get; set; }
        public int qtyOrdered { get; set; } = 0;
        public decimal subTotal => (decimal)qtyOrdered * decimal.Parse(product.price);


        //public int shoppingBasketSummaryId { get; set; }
        public ShoppingBasketItem() { }
        public ShoppingBasketItem(Product product, int qtyOrdered)
        {
            this.product = product;
            this.qtyOrdered = qtyOrdered;
        }
    }
}

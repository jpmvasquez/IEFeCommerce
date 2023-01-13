using TesteClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteClient.Data.ViewModels
{
    public class ShoppingBasketVM
    {
        public ShoppingBasketSummary shoppingBasketSummary { get; set; }
        public decimal totalPrice { get; set; }
    }
}

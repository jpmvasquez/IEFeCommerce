using TesteClient.Data.ViewModels;
using TesteClient.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteClient.Data
{
    public class ShoppingBasketSummary
    {
        public static ShoppingBasketSummary _shoppingBasketSummary;
        public ApplicationDbContext _context { get; set; }

        public string ShoppingBasketId { get; set; }

        public List<ShoppingBasketItem> shoppingBasketItems { get; set; }

        public ShoppingBasketSummary(ApplicationDbContext context)
        {
            _context = context;
        }
        public ShoppingBasketSummary() { }

        public static void populateShoppingBasketSummary(ShoppingBasketSummary shoppingBasketSummary)
        {
            _shoppingBasketSummary = shoppingBasketSummary;
        }

        public static ShoppingBasketSummary getShoppingBasketSummary()
        {
            return _shoppingBasketSummary;
        }

        public decimal GetShoppingBasketTotal() =>  shoppingBasketItems.Sum(si => si.subTotal);
    }
}

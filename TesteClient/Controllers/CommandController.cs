using TesteClient.Data;
using TesteClient.Data.ViewModels;
using TesteClient.Models.Products;
using TesteClient.Models.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TesteClient.Models;

namespace TesteClient.Controllers
{
    public class CommandController : Controller
    {
        private readonly ApplicationDbContext _context;

        public static List<Product> _productsList = new List<Product>();
        public static List<Product> _selectedProductsList = new List<Product>();
        public static List<ShoppingBasketItem> _shoppingBasketItems = new List<ShoppingBasketItem>();
        public static ShoppingBasketSummary _shoppingBasketSummary = new ShoppingBasketSummary();
        public static ShoppingBasketVM _shoppingBasketVM = new ShoppingBasketVM();

        public CommandController(ApplicationDbContext context)
        {
            _context = context;
            _productsList = _context
                .Product
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productBrand)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CompleteOrder()
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (ShoppingBasketItem shoppingBasketItem in _shoppingBasketSummary.shoppingBasketItems)
                orderDetails.Add(new OrderDetails()
                {
                    qty = shoppingBasketItem.qtyOrdered,
                    price = shoppingBasketItem.subTotal,
                    product = shoppingBasketItem.product,
                });
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser currentUser = _context.Users.Find(userId);
            List<ApplicationUserAdresse> currentUserAddresses = currentUser.ApplicationUserAdresses;
            
            return View("Order", orderDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompleteOrder(Order order)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.OrderDetails
                .Include(od => od.product)
                .Include(od => od.order);
            _context.Order
                .Include(o => o.address)
                .Include(o => o.user);
            return View("Order", order);
        }

        [HttpPost]
        public IActionResult ShoppingBasket()
        {
            _shoppingBasketSummary = ShoppingBasketSummary.getShoppingBasketSummary();
            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            return View("ShoppingBasketSumary", _shoppingBasketVM);
        }

        public IActionResult RemoveProdFromShoppingBasket(int id)
        {
            if (_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList().Count != 0)
            {
                if (_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered == 1)
                    _shoppingBasketSummary.shoppingBasketItems.Remove(_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0]);
                else
                    _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered = _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered - 1;
            }

            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            ViewBag.shoppingBasketVM = _shoppingBasketVM;

            return View("ShoppingBasketSumary", _shoppingBasketVM);
        }

        public IActionResult AddProdToShoppingBasket(int id)
        {
            if (_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList().Count != 0)
                _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered = _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered + 1;

            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            ViewBag.shoppingBasketVM = _shoppingBasketVM;
            ShoppingBasketSummary.populateShoppingBasketSummary(_shoppingBasketSummary);

            return View("ShoppingBasketSumary", _shoppingBasketVM);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TesteClient.Data;
using TesteClient.Data.ViewModels;
using TesteClient.Models.Products;

namespace TesteClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public static List<ShoppingBasketItem> _shoppingBasketItems = new List<ShoppingBasketItem>();
        public static ShoppingBasketSummary _shoppingBasketSummary = new ShoppingBasketSummary();
        public static ShoppingBasketVM _shoppingBasketVM = new ShoppingBasketVM();

        public static List<Product> _productsList = new List<Product>();
        public static List<Product> _selectedProductsList = new List<Product>();
        //public static List<ShoppingBasketItem> _shoppingBasketItems = new List<ShoppingBasketItem>();
        //public static ShoppingBasketSummary _shoppingBasketSummary = new ShoppingBasketSummary();
        //public static ShoppingBasketVM _shoppingBasketVM = new ShoppingBasketVM();

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            _productsList = _context.Product
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productBrand)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .ToList();
            var ReturnValue = _context
                 .Product
                 .Include(p => p.image)
                 .Include(p => p.productDetails)
                 .Include(p => p.productBrand)
                 .Include(p => p.productTechno)
                 .Include(p => p.productType)
                 .ToList();
            return View(ReturnValue);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult AddProductToBasket(int productId)
        {
            if (_shoppingBasketItems.Where(s => s.product.id == productId).ToList().Count != 0)
            {
                _shoppingBasketItems.Where(s => s.product.id == productId).ToList()[0].qtyOrdered = _shoppingBasketItems.Where(s => s.product.id == productId).ToList()[0].qtyOrdered + 1;
            }
            else
            {
                if (_productsList.Where(p => p.id == productId).ToList().Count != 0)
                {
                    ShoppingBasketItem shppingBasketItem = new ShoppingBasketItem();
                    shppingBasketItem.product = _productsList.Where(p => p.id == productId).ToList()[0];
                    //selectedProductsList.Where(p => p.id == productId).ToList()[0].qtyOrdered = qtyOrdred = 1;
                    _shoppingBasketItems.Add(new ShoppingBasketItem()
                    {
                        product = _productsList.Where(p => p.id == productId).ToList()[0],
                        qtyOrdered = 1
                    });
                    //shoppingBasketItems.Where(p => p.id == productId).ToList()[0].qtyOrdered = selectedProductsList.Where(p => p.id == productId).ToList()[0].qtyOrdered + 1;
                }
            }
            _shoppingBasketSummary.shoppingBasketItems = _shoppingBasketItems;
            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            ViewBag.shoppingBasketVM = _shoppingBasketVM;
            ShoppingBasketSummary.populateShoppingBasketSummary(_shoppingBasketSummary);
            return View("Index", _productsList);
        }
    }
}

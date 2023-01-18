using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteClient.Data;
using TesteClient.Data.ViewModels;
using TesteClient.Models.ClientsRating;
using TesteClient.Models.Products;

namespace TesteClient.Controllers
{
    public class ProductRatingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductRatingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Add(int productId)
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProdRatingViewModel prodRatingVM)
        {
            var comment = prodRatingVM.comment;
            var productId = prodRatingVM.productId;
            var rating = prodRatingVM.rating;
            ProductRating prodRating = new ProductRating()
            {
                productId = productId,
                rating = rating,
                comment = comment,
                publishedDate = DateTime.Now
            };
            _context.ProductRating.Add(prodRating);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProductRating
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductRating.Include(p => p.product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductRating/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductRating == null)
            {
                return NotFound();
            }

            var productRating = await _context.ProductRating
                .Include(p => p.product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (productRating == null)
            {
                return NotFound();
            }

            return View(productRating);
        }

        // GET: ProductRating/Create
        public IActionResult Create(int productId)
        {
            ProdRatingViewModel prodRatingVM = new ProdRatingViewModel();
            Product product = _context.Product
                .FirstOrDefault(p => p.id == productId);
            prodRatingVM.productId = productId;
            prodRatingVM.productName = product.name;
            return View(prodRatingVM);
        }

        // POST: ProductRating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("id,comment,publishedDate,productId,rating")]*/ ProductRating productRating)
        {
            productRating.publishedDate = DateTime.Now;
            //productRating.id = 0;
            if (ModelState.IsValid)
            {
                _context.Add(productRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["productId"] = new SelectList(_context.Product, "id", "name", productRating.productId);
            return View(productRating);
        }

        // GET: ProductRating/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductRating == null)
            {
                return NotFound();
            }

            var productRating = await _context.ProductRating.FindAsync(id);
            if (productRating == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.Product, "id", "name", productRating.productId);
            return View(productRating);
        }

        // POST: ProductRating/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,comment,publishedDate,productId,rating")] ProductRating productRating)
        {
            if (id != productRating.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductRatingExists(productRating.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["productId"] = new SelectList(_context.Product, "id", "name", productRating.productId);
            return View(productRating);
        }

        // GET: ProductRating/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductRating == null)
            {
                return NotFound();
            }

            var productRating = await _context.ProductRating
                .Include(p => p.product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (productRating == null)
            {
                return NotFound();
            }

            return View(productRating);
        }

        // POST: ProductRating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductRating == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductRating'  is null.");
            }
            var productRating = await _context.ProductRating.FindAsync(id);
            if (productRating != null)
            {
                _context.ProductRating.Remove(productRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductRatingExists(int id)
        {
          return _context.ProductRating.Any(e => e.id == id);
        }
    }
}

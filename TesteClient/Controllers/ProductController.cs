using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TesteClient.Data;
using TesteClient.Data.ViewModels;
using TesteClient.Models;
using TesteClient.Models.ClientsRating;
using TesteClient.Models.Products;

namespace TesteClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product
                .Include(p => p.productBrand)
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productTechno)
                .Include(p => p.productType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }



            //if (id == null)
            //    return BadRequest();

            //Product product = _context.Product.Find(id);
            //ProdRatingViewModel prodRatingVM = new ProdRatingViewModel();
            //if (product == null)
            //    return NotFound();

            //prodRatingVM.productId = id.Value;
            //prodRatingVM.productName = product.name;
            //List<ProductRating> prodRatings = _context.ProductRating
            //    .Where(pr => pr.productId == id.Value).ToList();
            //prodRatingVM.productRatings = prodRatings;

            //List<ProductRating> prodComments = _context.ProductRating
            //    .Where(pr => pr.productId == id.Value).ToList();
            //if (prodComments.Count() > 0)
            //{
            //    var ratingSum = prodComments.Sum(pc => pc.rating);
            //    ViewBag.RatingSum = ratingSum;
            //    var ratingCount = prodComments.Count();
            //    ViewBag.RatingCount = ratingCount;
            //}
            //else
            //{
            //    ViewBag.RatingSum = 0;
            //    ViewBag.RatingCount = 0;
            //}

            //return View(prodRatingVM);


            var product = await _context.Product
                .Include(p => p.productBrand)
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            //ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name");
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name");
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( /* [Bind("ProductName,Description,ImagePath,UnitPrice,CategoryID")]*/ Product product, [FromServices] IWebHostEnvironment _hostEnvironment)
        {
            ProductDetails prodDetails = product.productDetails;
            _context.ProductDetails.Add(prodDetails);

            Image prodImage = product.image;
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(product.image.formFile.FileName);
            string extension = Path.GetExtension(product.image.formFile.FileName);
            product.image.name = product.name + /*product.productDetails.productBrand.name +*/ extension;
            string path = Path.Combine(wwwRootPath + "/Content/" + product.image.name);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                product.image.formFile.CopyTo(fileStream);
            }
            _context.Image.Add(prodImage);
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name", product.productBrandId);
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name", product.productTechnoId);
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name", product.productTypeId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            //ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name");
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name");
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name");
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductName,Description,ImagePath,UnitPrice,CategoryID")] Product product)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
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
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name");
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name");
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name");
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.productBrand)
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Product.Any(e => e.id == id);
        }
    }
}

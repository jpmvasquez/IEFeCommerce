using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteClient.Data;
using TesteClient.Models;

namespace TesteClient.Controllers
{
    public class AdresseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdresseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adresse
        public async Task<IActionResult> Index()
        {
              return View(await _context.Adresses.ToListAsync());
        }

        // GET: Adresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Adresses == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adresse == null)
            {
                return NotFound();
            }

            return View(adresse);
        }

        // GET: Adresse/Create
        public IActionResult Create(string? Id)
        {
            ViewBag.IdCurrentApplicationUser = Id;
            return View();
        }

        // POST: Adresse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string? id, [Bind("Num,Road,Complement,ZipCode,City")] Adresse adresse)
        {
            string? IdClient = id;
            
            if (ModelState.IsValid)
            {
                _context.Add(adresse);
                await _context.SaveChangesAsync();
                if (IdClient != null)
                {
                    //int IdAddress = _context.Address
                    //    .OrderByDescending(p => p.Id)
                    //    .FirstOrDefault()
                    //    .Id;

                    ApplicationUserAdresse CurrentUserAddress = new ApplicationUserAdresse(IdClient, adresse.Id);
                    _context.ApplicationUserAdresse.Add(CurrentUserAddress);
                    await _context.SaveChangesAsync();

                    var routeValues = new RouteValueDictionary { { "id", IdClient } };
                    return RedirectToAction("Details", "ApplicationUser", routeValues);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(adresse);
        }

        // GET: Adresse/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Adresses == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresses.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }
            return View(adresse);
        }

        // POST: Adresse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Num,Road,Complement,ZipCode,City")] Adresse adresse)
        {
            if (id != adresse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdresseExists(adresse.Id))
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
            return View(adresse);
        }

        // GET: Adresse/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Adresses == null)
            {
                return NotFound();
            }

            var adresse = await _context.Adresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adresse == null)
            {
                return NotFound();
            }

            return View(adresse);
        }

        // POST: Adresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Adresses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Adresses'  is null.");
            }
            var adresse = await _context.Adresses.FindAsync(id);
            if (adresse != null)
            {
                _context.Adresses.Remove(adresse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdresseExists(int id)
        {
          return _context.Adresses.Any(e => e.Id == id);
        }
    }
}

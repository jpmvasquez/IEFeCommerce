using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteClient.Data;
using TesteClient.Models;

namespace TesteClient.Controllers
{
    public class ApplicationUserAdresseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserAdresseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUserAdresse
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationUserAdresse
                .Include(a => a.Adresse)
                .Include(a => a.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationUserAdresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ApplicationUserAdresse == null)
            {
                return NotFound();
            }

            var applicationUserAdresse = await _context.ApplicationUserAdresse
                .Include(a => a.Adresse)
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserAdresse == null)
            {
                return NotFound();
            }

            return View(applicationUserAdresse);
        }

        // GET: ApplicationUserAdresse/Create
        public IActionResult Create()
        {
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "Id", "Name");
            ViewData["IdApplicationUser"] = new SelectList(_context.ApplicationUser, "Id", "FullName");
            return View();
        }

        // POST: ApplicationUserAdresse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdApplicationUser,IdAdresse")] ApplicationUserAdresse applicationUserAdresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUserAdresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "Id", "Name", applicationUserAdresse.IdAdresse);
            ViewData["IdApplicationUser"] = new SelectList(_context.ApplicationUser, "Id", "Fullname", applicationUserAdresse.IdApplicationUser);
            return View(applicationUserAdresse);
        }

        // GET: ApplicationUserAdresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ApplicationUserAdresse == null)
            {
                return NotFound();
            }

            var applicationUserAdresse = await _context.ApplicationUserAdresse.FindAsync(id);
            if (applicationUserAdresse == null)
            {
                return NotFound();
            }
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "Id", "Id", applicationUserAdresse.IdAdresse);
            ViewData["IdApplicationUser"] = new SelectList(_context.ApplicationUser, "Id", "Id", applicationUserAdresse.IdApplicationUser);
            return View(applicationUserAdresse);
        }

        // POST: ApplicationUserAdresse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdApplicationUser,IdAdresse")] ApplicationUserAdresse applicationUserAdresse)
        {
            if (id != applicationUserAdresse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUserAdresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserAdresseExists(applicationUserAdresse.Id))
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
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "Id", "Id", applicationUserAdresse.IdAdresse);
            ViewData["IdApplicationUser"] = new SelectList(_context.ApplicationUser, "Id", "Id", applicationUserAdresse.IdApplicationUser);
            return View(applicationUserAdresse);
        }

        // GET: ApplicationUserAdresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ApplicationUserAdresse == null)
            {
                return NotFound();
            }

            var applicationUserAdresse = await _context.ApplicationUserAdresse
                .Include(a => a.Adresse)
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserAdresse == null)
            {
                return NotFound();
            }

            return View(applicationUserAdresse);
        }

        // POST: ApplicationUserAdresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ApplicationUserAdresse == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ApplicationUserAdresse'  is null.");
            }
            var applicationUserAdresse = await _context.ApplicationUserAdresse.FindAsync(id);
            if (applicationUserAdresse != null)
            {
                _context.ApplicationUserAdresse.Remove(applicationUserAdresse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserAdresseExists(int id)
        {
          return _context.ApplicationUserAdresse.Any(e => e.Id == id);
        }
    }
}

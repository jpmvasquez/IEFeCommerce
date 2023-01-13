using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TesteClient.Data;
using TesteClient.Models;

 namespace TesteClient
{

    public class ApplicationUserController : Controller
    {

        private readonly ApplicationDbContext _context;



        public ApplicationUserController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
           
            var dBcontext =  _context.Users
                .Include(t => t.ApplicationUserAdresses)
                .ThenInclude(t => t.Adresse)
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName);



            return View(await dBcontext.ToListAsync());
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .Include(t => t.ApplicationUserAdresses)
                .ThenInclude(t => t.Adresse)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }



    }

        

   
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteClient.Data;
using TesteClient.Models;

namespace TesteClient.Areas.Identity.Pages.Account.Manage
{
    public class AddAdressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AddAdressModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        //public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public ApplicationUserAdresse Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        //public class InputModel
        //{
        //    public int Id { get; set; }

        //    [DisplayName("Client")]
        //    public string IdApplicationUser { get; set; }

        //    [DisplayName("Adresse")]
        //    public int IdAdresse { get; set; }

        //    [ForeignKey("IdApplicationUser")]
        //    [DisplayName("Client")]
        //    public virtual ApplicationUser? ApplicationUser { get; set; }


        //    [ForeignKey("IdAdresse")]
        //    [DisplayName("Adresse")]
        //    public virtual Adresse? Adresse { get; set; }

        //}

        private async Task LoadAsync(ApplicationUser user)

        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            //Username = userName;




            //Input = new InputModel
            //{
            //     = phoneNumber,
            //    LastName = user.LastName,
            //    FirstName = user.FirstName,
            //    BirthDate = user.BirthDate,
            //    Id = user.Id

            //};
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Input.IdApplicationUser = user.Id;
            //if (!ModelState.IsValid)
            //{
            //    await LoadAsync(user);
            //    return Page();
            //}

            await _context.Adresses.AddAsync(Input.Adresse);
            //await _context.ApplicationUserAdresse.AddAsync(new ApplicationUserAdresse{ 
            //    IdApplicationUser = user.Id,
            //    IdAdresse = Input.Adresse.Id
            //});
            await _context.AddAsync(Input);
            await _context.SaveChangesAsync();

            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

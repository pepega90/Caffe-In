using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaffeIn.Pages.Account
{

    public class DaftarModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public DaftarModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public DaftarViewModel daftarViewModel { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = daftarViewModel.Email,
                    Email = daftarViewModel.Email
                };

                var createdUser = await userManager.CreateAsync(user, daftarViewModel.Password);

                if (createdUser.Succeeded)
                {
                    return RedirectToPage("Login");
                }
            }

            return Page();
        }
    }
}
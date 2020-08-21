using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaffeIn.Pages.User
{
    public class GantiPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public GantiPasswordModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public GantiPasswordViewModel GantiPass { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                var userChangePassword = await userManager
                    .ChangePasswordAsync(user, GantiPass.CurrentPassword, GantiPass.NewPassword);

                if (userChangePassword.Succeeded)
                {
                    return RedirectToPage("SuccessChangePassword");
                }
            }

            return Page();
        }
    }
}
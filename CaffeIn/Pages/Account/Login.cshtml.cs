using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaffeIn.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel loginViewModel { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginUser = await signInManager.PasswordSignInAsync(loginViewModel.Email,
                                loginViewModel.Password, loginViewModel.RememberMe, false);

                if (loginUser.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
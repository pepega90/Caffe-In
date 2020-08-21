using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Services;
using CaffeIn.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaffeIn.Pages.User
{
    [Authorize]
    public class MyOrderModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICartItemRepository cartItemRepository;
        private readonly IKopiRepository kopiRepository;

        public MyOrderModel(UserManager<ApplicationUser> userManager,
                            ICartItemRepository cartItemRepository,
                            IKopiRepository kopiRepository)
        {
            this.userManager = userManager;
            this.cartItemRepository = cartItemRepository;
            this.kopiRepository = kopiRepository;
        }

        public IEnumerable<CartItem> MyCart { get; set; }
        public decimal Total { get; set; }

        public void OnGet()
        {
            MyCart = cartItemRepository.GetMyCart();
        }


        public IActionResult OnPostHapusFromCart(int kopiId, string userId)
        {
            var kopi = kopiRepository.FindKopiById(kopiId);

            if(kopi != null)
            {
                cartItemRepository.RemoveFromCart(kopi, userId);
            }

            return RedirectToPage("MyOrder");
        }

        public IActionResult OnPostClearCart(int cartId, string userId)
        {
            var cartItem = cartItemRepository.FindCartById(cartId);

            if (cartItem != null)
            {
                cartItemRepository.ClearCart(userId);
                return RedirectToPage("DoneBayar");
            }

            return Page();

        }
    }
}
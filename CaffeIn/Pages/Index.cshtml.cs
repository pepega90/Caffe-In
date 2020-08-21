using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Services;
using CaffeIn.Services.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace CaffeIn.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IKopiRepository kopiRepository;
        private readonly ICartItemRepository cartItemRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public IndexModel(ILogger<IndexModel> logger,
                          IKopiRepository kopiRepository,
                          ICartItemRepository cartItemRepository,
                          UserManager<ApplicationUser> userManager,
                          AppDbContext appDbContext)
        {
            _logger = logger;
            this.kopiRepository = kopiRepository;
            this.cartItemRepository = cartItemRepository;
            this.userManager = userManager;
        }

        public IEnumerable<Kopi> AllKopi { get; set; }

        [BindProperty]
        public int kopiId { get; set; }

        public void OnGet()
        {
            AllKopi = kopiRepository.GetAllKopi();
        }

        /// <summary>
        /// 
        ///  Bikin pagination di List kopi pages
        ///  dan mungkin fungsi search
        ///  
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> OnPost()
        {
            var user = await userManager.GetUserAsync(User);

            var selectedKopi = kopiRepository.FindKopiById(kopiId);

            if(selectedKopi != null)
            {
                cartItemRepository.AddToCart(selectedKopi, 1, user.Id);
            }

            return RedirectToPage("/ListKopi");
        }
    }
}

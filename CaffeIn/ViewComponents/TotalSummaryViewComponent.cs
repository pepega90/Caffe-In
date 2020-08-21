using CaffeIn.Models.ViewModel;
using CaffeIn.Services;
using CaffeIn.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeIn.ViewComponents
{
    public class TotalSummaryViewComponent : ViewComponent
    {
        private readonly ICartItemRepository cartItemRepository;

        public TotalSummaryViewComponent(ICartItemRepository cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
        }

        public IViewComponentResult Invoke(string userId)
        {
            var result = cartItemRepository.GetShoppingCartTotal(userId);
            var shoppingCartTotalViewModel = new TotalSummaryViewModel()
            {
                ShoppingCartTotal = result
            };

            return View(shoppingCartTotalViewModel);
        }
    }
}

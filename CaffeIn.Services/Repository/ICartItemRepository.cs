using CaffeIn.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeIn.Services.Repository
{
    public interface ICartItemRepository
    {
        void AddToCart(Kopi kopi, int qyt, string userId);

        IEnumerable<CartItem> GetMyCart();

        decimal GetShoppingCartTotal(string userId);

        void RemoveFromCart(Kopi kopi, string userId);

        void ClearCart(string userId);

        CartItem FindCartById(int cartId);
    }
}

using CaffeIn.Models;
using CaffeIn.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace CaffeIn.Services
{
    /// <summary>
    /// 
    /// benerin my order pages
    /// sama fungsi add to cart
    /// 
    /// </summary>
    /// <returns></returns>

    public class CartRepository : ICartItemRepository
    {
        private readonly AppDbContext context;

        public CartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddToCart(Kopi kopi, int qyt, string userId)
        {
            var shoppingCartItems = context.ShoopingCartItems.SingleOrDefault(
                s => s.Kopi.Id == kopi.Id);

            if (shoppingCartItems == null)
            {
                shoppingCartItems = new CartItem
                {
                    Kopi = kopi,
                    KopiId = kopi.Id,
                    Quantity = qyt,
                    UserId = userId,
                };

                context.ShoopingCartItems.Add(shoppingCartItems);
            }
            else
            {
                shoppingCartItems.Quantity++;
            }

            context.SaveChanges();
        }

        public void ClearCart(string userId)
        {
            var cartItem = context
                .ShoopingCartItems
                .Where(e => e.UserId == userId);

            context.ShoopingCartItems.RemoveRange(cartItem);

            context.SaveChanges();
        }

        public CartItem FindCartById(int cartId)
        {
            return context.ShoopingCartItems.Find(cartId);
        }

        public IEnumerable<CartItem> GetMyCart()
        {
            return context.ShoopingCartItems.Include(s => s.Kopi);
        }

        public decimal GetShoppingCartTotal(string userId)
        {
            var total = context.ShoopingCartItems.Where(e => e.UserId == userId)
                .Select(x => x.Kopi.Harga * x.Quantity).Sum();

            return total;
        }

        public void RemoveFromCart(Kopi kopi, string userId)
        {
            var cartItem = context.ShoopingCartItems.
                SingleOrDefault(e => e.KopiId == kopi.Id && e.UserId == userId);

            var localQuantity = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    localQuantity = cartItem.Quantity;
                }
                else
                {
                    context.ShoopingCartItems.Remove(cartItem);
                }
            }

            context.SaveChanges();

            //return localQuantity;
        }
    }
}

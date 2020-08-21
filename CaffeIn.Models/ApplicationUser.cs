using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeIn.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}

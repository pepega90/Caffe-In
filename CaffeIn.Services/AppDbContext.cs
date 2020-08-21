using CaffeIn.Models;
using CaffeIn.Services.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeIn.Services
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Kopi> Kopis { get; set; }
        public DbSet<CartItem> ShoopingCartItems { get; set; }

    }
}

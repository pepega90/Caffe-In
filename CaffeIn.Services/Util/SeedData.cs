using CaffeIn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CaffeIn.Services.Util
{
    public static class SeedData
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var hasherPassword = new PasswordHasher<ApplicationUser>();

            // Add admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasherPassword.HashPassword(null, "admin1")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1",
                });

        }
    }
}

using Challenge.Movies.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Identity
{


    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext()
        {

        }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });

            //Seeding a  'User' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "4405d273-6c83-4479-9ad3-cff1673349a0", Name = "User", NormalizedName = "USER".ToUpper() });

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();


            //Seeding the Admin to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "roberto",
                    NormalizedUserName = "ROBERTO",
                    Email = "roberto@admin.com",
                     NormalizedEmail = "ROBERTO@ADMIN.COM",
                    FirstName = "Roberto",
                    LastName = "Flores",
                     EmailConfirmed = true,
                     LockoutEnabled = true,
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "0688dfc5-a6fe-4cfe-ab54-9057aa756c7a", // primary key
                    UserName = "Ana",
                    NormalizedUserName = "ANA",
                    Email = "ana@user.com",
                    NormalizedEmail = "ANA@USER.COM",
                    FirstName = "ANA",
                    LastName = "FLORES",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );


            //Seeding the relation between our ADMIN and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );


            //Seeding the relation between our USER and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4405d273-6c83-4479-9ad3-cff1673349a0",
                    UserId = "0688dfc5-a6fe-4cfe-ab54-9057aa756c7a"
                }
            );
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

    }

}



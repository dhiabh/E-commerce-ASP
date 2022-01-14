using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_commerce_ASP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("User")]
        public int RefId { get; set; }
        public User User { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<E_commerce_ASP.Models.ApplicationUser> ApplicationUsers { get; set; }
        public System.Data.Entity.DbSet<E_commerce_ASP.Models.User> RealUsers { get; set; }
        public System.Data.Entity.DbSet<E_commerce_ASP.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<E_commerce_ASP.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<E_commerce_ASP.Models.Historique> Historiques { get; set; }
        public System.Data.Entity.DbSet<E_commerce_ASP.Models.Problem> Problems { get; set; }




    }
}
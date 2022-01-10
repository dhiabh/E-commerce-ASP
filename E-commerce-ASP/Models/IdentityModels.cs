using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString ="{0:dd--MM-yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Display(Name = "Web site")]
        public string WebSite { get; set; }

        [Display(Name = "Patent number")]
        public string NumPatente { get; set; }
        public List<string> Problems { get; set; }
        public string Nature { get; set; }
        public string Address { get; set; }
        public bool IsInFavList { get; set; }
        public bool IsInBlackList { get; set; }
        public ICollection<Product> Products { get; set; }
        public ApplicationUser()
        {
            IsInFavList = false;
            IsInBlackList = false;
            Problems = new List<string>();
            Products = new List<Product>();
        }
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
    }
}
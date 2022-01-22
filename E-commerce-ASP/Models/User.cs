using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_commerce_ASP.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RealId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        

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
        public User()
        {
            IsInFavList = false;
            IsInBlackList = false;
            Problems = new List<string>();
            Products = new List<Product>();
        }

        public string Problem { get; set; }
    }
}
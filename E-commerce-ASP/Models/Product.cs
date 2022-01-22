using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_commerce_ASP.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.Product), ErrorMessageResourceName ="ProductNameRequired")]
        [Display(Name = "ProductName", ResourceType = typeof(E_commerce_ASP.Resources.Models.Product))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.Product), ErrorMessageResourceName = "ProductPriceRequired")]
        [Display(Name = "ProductPrice", ResourceType = typeof(E_commerce_ASP.Resources.Models.Product))]
        public decimal Price { get; set; }

        //[Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.Product), ErrorMessageResourceName = "ProductImageRequired")]
        [Display(Name = "ChoosePicture", ResourceType = typeof(E_commerce_ASP.Resources.Models.Product))]
        public string Image { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.Product), ErrorMessageResourceName = "ProductDescRequired")]
        [Display(Name = "ProductDesc", ResourceType = typeof(E_commerce_ASP.Resources.Models.Product))]
        public string Description { get; set; }
        public bool IsInFavList { get; set; }
        public bool IsInBlackList { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.Product), ErrorMessageResourceName = "ProductCategRequired")]
        [Display(Name = "ProductCateg", ResourceType = typeof(E_commerce_ASP.Resources.Models.Product))]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public Product()
        {
            IsInFavList = false;
            IsInBlackList = false;
        }
    }
}
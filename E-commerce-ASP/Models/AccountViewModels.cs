using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_ASP.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "EmailRequired")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "RegistrationTypeRequired")]
        [Display(Name = "RegistrationType", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string Nature { get; set; }
        
    }

    public class ParticularViewModel
    {
        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "FirstNameRequired")]
        [Display(Name = "FirstName", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "LastNameRequired")]
        [Display(Name = "LastName", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "PhoneNumberRequired")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "AddressRequired")]
        [Display(Name = "Address", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string Address { get; set; }
    }

    public class CompanyViewModel
    {
        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "CompanyNameRequired")]
        [Display(Name = "CompanyName", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string CompanyName { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "WebSiteRequired")]
        [Display(Name = "WebSite", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string WebSite { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "PatentNumberRequired")]
        [Display(Name = "PatentNumber", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string NumPatente { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "PhoneNumberRequired")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels), ErrorMessageResourceName = "AddressRequired")]
        [Display(Name = "Address", ResourceType = typeof(E_commerce_ASP.Resources.Models.AccountViewModels))]
        public string Address { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

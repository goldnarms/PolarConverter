﻿using Foolproof;
using PolarConverter.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PolarConverter.JSWeb.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string Email { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [RequiredIf("ProviderType", Operator.EqualTo, ProviderType.Local)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Enter your weight")]
        //[MaxLength(3, ErrorMessage = "The {0} can not be longer than 3 characters")]
        public double Weight { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Enter your email that you registered with Strava(if any)")]
        public string StravaEmail { get; set; }

        [Display(Name = "Check if you want to the converted files to appear as they came from a Garmin watch.")]
        public bool ForceGarmin { get; set; }

        [Required]
        [Display(Name="Kgs or Lbs")]
        public bool PreferKg { get; set; }

        [Required]
        [Display(Name = "Select gender")]
        public bool IsMale { get; set; }

        //[Required]
        [Display(Name = "Preferred timezone")]
        public double TimeZoneOffset { get; set; }

        [Required]
        [Display(Name = "Select your birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string BirthDate { get; set; }

        public string AccessToken { get; set; }

		public string ProviderUsername { get; set; }

		public ProviderType ProviderType { get; set; }
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

}

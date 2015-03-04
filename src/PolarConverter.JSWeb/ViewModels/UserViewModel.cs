using System;
using System.Collections.Generic;
using PolarConverter.JSWeb.Models;
using PolarConverter.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PolarConverter.JSWeb.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Weight")]
        public Nullable<double> Weight { get; set; }
        [Display(Name = "Kgs or Lbs")]
        public bool PreferKg { get; set; }
        [Display(Name = "Gender")]
        public bool IsMale { get; set; }
        [Display(Name = "Date of birth")]
        public Nullable<DateTime> BirthDate { get; set; }
        public List<RegisteredProvider> Providers { get; set; }
        public Subscription ActiveSubscription { get; set; }

        public double TimezoneOffset { get; set; }

        public bool ForceGarmin { get; set; }
    }

	public class RegisteredProvider
	{
		public ProviderType ProviderType { get; set; }
		public string Username { get; set; }
	}
}
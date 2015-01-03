using System;
using System.Collections.Generic;
using PolarConverter.JSWeb.Models;
using PolarConverter.DAL.Models;

namespace PolarConverter.JSWeb.ViewModels
{
    public class UserViewModel
    {
        public double Weight { get; set; }
        public bool PreferKg { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public List<ProviderType> RegisteredProviders { get; set; }
        public Subscription ActiveSubscription { get; set; }
    }
}
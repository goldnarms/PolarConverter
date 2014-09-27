using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolarConverter.JSWeb.Models
{
    public class OauthToken
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Key, Column(Order = 1)]
        public ProviderType ProviderType { get; set; }
        public string Token { get; set; }
    }

    public enum ProviderType
    {
        Strava
    }
}
using PolarConverter.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Secret { get; set; }

		public string Username { get; set; }
	}
}
namespace PolarConverter.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OauthToken
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProviderType { get; set; }

        public string Token { get; set; }

        public string Secret { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}

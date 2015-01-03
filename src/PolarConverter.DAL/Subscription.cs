namespace PolarConverter.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscription
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Paid { get; set; }

        public string SubscriptionId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}

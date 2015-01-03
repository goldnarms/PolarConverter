namespace PolarConverter.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserFile
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Reference { get; set; }

        public int Activity { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}

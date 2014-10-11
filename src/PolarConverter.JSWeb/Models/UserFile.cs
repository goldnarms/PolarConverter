using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolarConverter.JSWeb.Models
{
    public class UserFile
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Key, Column(Order = 1)]
        public string FileRef { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
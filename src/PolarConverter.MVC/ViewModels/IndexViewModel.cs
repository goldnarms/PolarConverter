using System.Collections.Generic;
using PolarConverter.BLL.Entiteter;

namespace PolarConverter.MVC.ViewModels
{
    using System.ComponentModel.DataAnnotations;


    public class IndexViewModel
    {
        public int AntallDropboxItems { get; set; }

        public List<DropboxItem> DropboxItems { get; set; }

        public bool DropboxAutorisert { get; set; }

        public bool? ViserDropbox { get; set; }

        [Display(Name = "Your weight")]
        public double? Vekt { get; set; }

        [Display(Name = "Sport")]
        public string Sport { get; set; }

        [Display(Name="You want to automatically send your files to Strava?")]
        public bool SendTilStrava { get; set; }

        [Display(Name="Your Strava username")]
        public string StravaBrukernavn { get; set; }

        [Display(Name = "Choose timezone")]
        public string TimeZoneCorrection { get; set; }

        public string Message { get; set; }

        public string BrukerGuid { get; set; }

        public string Notat { get; set; }

        [Display(Name = "Act as a Garmin device(for compability issues)")]
        public bool ForceGarmin { get; set; }
    }
}
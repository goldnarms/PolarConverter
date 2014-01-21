using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PolarConverter.BLL.Entiteter
{
    public class BrukerModel
    {
        public int AntallDropboxItems { get; set; }

        public List<DropboxItem> DropboxItems { get; set; }

        public bool DropboxAutorisert { get; set; }

        [Display(Name = "Your weight")]
        public double? Vekt { get; set; }

        [Display(Name = "Sport")]
        public string Sport { get; set; }

        [Display(Name = "You want to automatically send your files to Strava?")]
        public bool SendTilStrava { get; set; }

        [Display(Name = "Your Strava username")]
        public string StravaBrukernavn { get; set; }

        [Display(Name = "Choose timezone")]
        public string TimeZoneCorrection { get; set; }

        public string Message { get; set; }

        public string BrukerGuid { get; set; }

        public string Notat { get; set; }

        public bool ForceGarmin { get; set; }
    }
}

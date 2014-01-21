using System;
using System.ComponentModel.DataAnnotations;

namespace PolarConverter.BLL.Entiteter
{
    public class DropboxItem
    {
        public string Filnavn { get; set; }
        public bool Valgt { get; set; }
        public string Notat { get; set; }
        [Display(Name = "Sport")]
        public string Sport { get; set; }

        public string TilpassetFilnavn
        {
            get
            {
                if (Filnavn.Length > 8)
                {
                    DateTime dato;
                    var tekstDato = string.Format("20{0}.{1}.{2}", Filnavn.Substring(0, 2), Filnavn.Substring(2, 2),
                                                  Filnavn.Substring(4, 2));
                    if (DateTime.TryParse(tekstDato, out dato))
                        return string.Format("{0}({1})", dato.ToShortDateString(), Filnavn.Substring(6, 2));
                }
                var i = 0;
                int tall;
                while (i < Filnavn.Length && !int.TryParse(Filnavn[i].ToString(), out tall))
                {
                    i++;
                }

                return Filnavn.Length >= i + 10 ? Filnavn.Substring(i, 10) : Filnavn;
            }
        }
    }
}

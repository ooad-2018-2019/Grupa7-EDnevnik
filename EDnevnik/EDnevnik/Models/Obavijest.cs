using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Obavijest
    {
        public int ObavijestId { get; set; }
        public String Text { get; set; }
        public DateTime Datum { get; set; }
        public int NastavnikId { get; set; }

        public virtual Nastavnik Nastavnik { get; set; }

        public Obavijest(int obavijestId, string text, DateTime datum, Nastavnik nastavnik)
        {
            ObavijestId = obavijestId;
            Text = text;
            Datum = datum;
            NastavnikId = nastavnik.KorisnikId;
            Nastavnik = nastavnik;
        }

        public Obavijest()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Razred
    {
        public Razred(int razredId, int broj, Nastavnik nastavnik)
        {
            RazredId = razredId;
            NastavnikId = nastavnik.KorisnikId;
            Broj = broj;
            Nastavnik = nastavnik;
        }

        public int RazredId { get; set; }
        public int NastavnikId { get; set; }
        public int Broj { get; set; }

        public virtual Nastavnik Nastavnik { get; set; }
    }
}

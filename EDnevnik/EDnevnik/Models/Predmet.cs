using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Predmet
    {
        public Predmet(int predmetId, string naziv, string opis, string literatura, int godina, Nastavnik nastavnik)
        {
            PredmetId = predmetId;
            Naziv = naziv;
            Opis = opis;
            Literatura = literatura;
            NastavnikId = nastavnik.KorisnikId;
            Godina = godina;
            Nastavnik = nastavnik;
        }

        public int PredmetId { get; set; }
        public String Naziv { get; set; }
        public String Opis { get; set; }
        public String Literatura { get; set; }
        public int NastavnikId { get; set; }
        public int Godina { get; set; }

        public virtual Nastavnik Nastavnik { get; set; }
    }
}

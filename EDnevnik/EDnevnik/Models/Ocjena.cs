using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Ocjena
    {
        public Ocjena(int ocjenaId, int vrijednost, DateTime datum, Ucenik ucenik, Predmet predmet)
        {
            OcjenaId = ocjenaId;
            UcenikId = ucenik.KorisnikId;
            PredmetId = predmet.PredmetId;
            Vrijednost = vrijednost;
            Datum = datum;
            Ucenik = ucenik;
            Predmet = predmet;
        }

        public int OcjenaId { get; set; }
        public int UcenikId { get; set; }
        public int PredmetId { get; set; }
        public int Vrijednost { get; set; }
        public DateTime Datum { get; set; }

        public virtual Ucenik Ucenik { get; set; }
        public virtual Predmet Predmet { get; set; }


    }
}

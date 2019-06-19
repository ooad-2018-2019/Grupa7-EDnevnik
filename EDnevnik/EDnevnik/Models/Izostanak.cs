using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Izostanak
    {
        public int IzostanakId { get; set; }
        public int UcenikId { get; set; }
        public int PredmetId { get; set; }
        public DateTime Datum { get; set; }
        public bool Opravdan { get; set; }

        public virtual Ucenik Ucenik { get; set; }
        public virtual Predmet Predmet { get; set; }

        public Izostanak(int id, Ucenik ucenik, Predmet predmet, DateTime datum, bool opravdan)
        {
            IzostanakId = id;
            UcenikId = ucenik.KorisnikId;
            PredmetId = predmet.PredmetId;
            Datum = datum;
            Opravdan = opravdan;
            Ucenik = ucenik;
            Predmet = predmet;
        }

        public Izostanak()
        {

        }
    }
}

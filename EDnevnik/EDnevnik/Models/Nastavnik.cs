using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Nastavnik : Korisnik
    {
        public String tip_korisnika { get; set; }

        protected Nastavnik(int korisnikId, string ime, string prezime, string username, string password, DateTime datumRodjenja, string jMBG) : base(korisnikId, ime, prezime, username, password, datumRodjenja, jMBG)
        {
        }

        public Nastavnik()
        {

        }
    }
}

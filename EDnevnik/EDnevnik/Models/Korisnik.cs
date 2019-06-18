using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public abstract class Korisnik
    {
        protected Korisnik(int korisnikId, string ime, string prezime, string username, string password, DateTime datumRodjenja, string jMBG)
        {
            KorisnikId = korisnikId;
            Ime = ime;
            Prezime = prezime;
            Username = username;
            Password = password;
            DatumRodjenja = datumRodjenja;
            JMBG = jMBG;
        }

        public int KorisnikId { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String JMBG { get; set; }
        public int PravoPristupa { get; set; }
    }
}

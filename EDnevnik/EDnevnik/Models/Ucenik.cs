using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class Ucenik : Korisnik
    {
        public int RoditeljId { get; set; }
        public int RazredId { get; set; }

        public virtual Roditelj Roditelj { get; set; }
        public virtual Razred Razred { get; set; }

        public String tip_korisnika { get; set; }

        protected Ucenik(int korisnikId, string ime, string prezime, string username, string password, DateTime datumRodjenja, string jMBG, Roditelj roditelj, Razred razred) : base(korisnikId, ime, prezime, username, password, datumRodjenja, jMBG)
        {
            RoditeljId = roditelj.KorisnikId;
            RazredId = razred.RazredId;
            Roditelj = roditelj;
            Razred = razred;
        }

        public Ucenik()
        {

        }
    }
}

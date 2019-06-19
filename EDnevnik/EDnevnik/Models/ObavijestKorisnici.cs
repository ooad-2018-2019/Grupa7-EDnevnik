using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{
    public class ObavijestKorisnici
    {
        public ObavijestKorisnici(int obavijestKorisniciId, Korisnik korisnik, Obavijest obavijest)
        {
            ObavijestKorisniciId = obavijestKorisniciId;
            KorisnikId = korisnik.KorisnikId;
            ObavijestId = obavijest.ObavijestId;
            Korisnik = korisnik;
            Obavijest = obavijest;
        }

        public int ObavijestKorisniciId { get; set; }
        public int KorisnikId { get; set; }
        public int ObavijestId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Obavijest Obavijest { get; set; }

        public ObavijestKorisnici()
        {

        }
    }
}

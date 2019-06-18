﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDnevnik.Models
{   
    public class Roditelj : Korisnik
    {
        public String tip_korisnika { get; set; }

        protected Roditelj(int korisnikId, string ime, string prezime, string username, string password, DateTime datumRodjenja, string jMBG) : base(korisnikId, ime, prezime, username, password, datumRodjenja, jMBG)
        {
            PravoPristupa = 1;
        }
    }
}

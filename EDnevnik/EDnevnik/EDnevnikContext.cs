using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EDnevnik.Models;

namespace EDnevnik
{
    public class EDnevnikContext:DbContext
    {
        public static EDnevnikContext instance;

        public EDnevnikContext(DbContextOptions<EDnevnikContext> options) : base(options) { instance = this; }

        public DbSet<Ucenik> Ucenik { get; set; }
        public DbSet<Roditelj> Roditelj { get; set; }
        public DbSet<Nastavnik> Nastavnik { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Razred> Razred { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<Izostanak> Izostanak { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<ObavijestKorisnici> ObavijestKorisnici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik").HasDiscriminator<String>("tip_korisnika");
            modelBuilder.Entity<Predmet>().ToTable("Predmet");
            modelBuilder.Entity<Razred>().ToTable("Razred");
            modelBuilder.Entity<Obavijest>().ToTable("Obavijest");
            modelBuilder.Entity<Izostanak>().ToTable("Izostanak");
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<Ocjena>().ToTable("Ocjena");
            modelBuilder.Entity<ObavijestKorisnici>().ToTable("ObavijestKorisnici");
        }
    }
}

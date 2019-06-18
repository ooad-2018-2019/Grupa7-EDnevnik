﻿// <auto-generated />
using System;
using EDnevnik;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDnevnik.Migrations
{
    [DbContext(typeof(EDnevnikContext))]
    [Migration("20190618133659_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDnevnik.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("AdministratorId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("EDnevnik.Models.Izostanak", b =>
                {
                    b.Property<int>("IzostanakId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<bool>("Opravdan");

                    b.Property<int>("PredmetId");

                    b.Property<int>("UcenikId");

                    b.HasKey("IzostanakId");

                    b.HasIndex("PredmetId");

                    b.HasIndex("UcenikId");

                    b.ToTable("Izostanak");
                });

            modelBuilder.Entity("EDnevnik.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<string>("Password");

                    b.Property<int>("PravoPristupa");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.Property<string>("tip_korisnika")
                        .IsRequired();

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnik");

                    b.HasDiscriminator<string>("tip_korisnika").HasValue("Korisnik");
                });

            modelBuilder.Entity("EDnevnik.Models.Obavijest", b =>
                {
                    b.Property<int>("ObavijestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int>("NastavnikId");

                    b.Property<string>("Text");

                    b.HasKey("ObavijestId");

                    b.HasIndex("NastavnikId");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("EDnevnik.Models.ObavijestKorisnici", b =>
                {
                    b.Property<int>("ObavijestKorisniciId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId");

                    b.Property<int>("ObavijestId");

                    b.HasKey("ObavijestKorisniciId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ObavijestId");

                    b.ToTable("ObavijestKorisnici");
                });

            modelBuilder.Entity("EDnevnik.Models.Ocjena", b =>
                {
                    b.Property<int>("OcjenaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int>("PredmetId");

                    b.Property<int>("UcenikId");

                    b.Property<int>("Vrijednost");

                    b.HasKey("OcjenaId");

                    b.HasIndex("PredmetId");

                    b.HasIndex("UcenikId");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("EDnevnik.Models.Predmet", b =>
                {
                    b.Property<int>("PredmetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Godina");

                    b.Property<string>("Literatura");

                    b.Property<int>("NastavnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("PredmetId");

                    b.HasIndex("NastavnikId");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("EDnevnik.Models.Razred", b =>
                {
                    b.Property<int>("RazredId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Broj");

                    b.Property<int>("NastavnikId");

                    b.HasKey("RazredId");

                    b.HasIndex("NastavnikId");

                    b.ToTable("Razred");
                });

            modelBuilder.Entity("EDnevnik.Models.Nastavnik", b =>
                {
                    b.HasBaseType("EDnevnik.Models.Korisnik");

                    b.ToTable("Nastavnik");

                    b.HasDiscriminator().HasValue("Nastavnik");
                });

            modelBuilder.Entity("EDnevnik.Models.Roditelj", b =>
                {
                    b.HasBaseType("EDnevnik.Models.Korisnik");

                    b.ToTable("Roditelj");

                    b.HasDiscriminator().HasValue("Roditelj");
                });

            modelBuilder.Entity("EDnevnik.Models.Ucenik", b =>
                {
                    b.HasBaseType("EDnevnik.Models.Korisnik");

                    b.Property<int>("RazredId");

                    b.Property<int>("RoditeljId");

                    b.HasIndex("RazredId");

                    b.HasIndex("RoditeljId");

                    b.ToTable("Ucenik");

                    b.HasDiscriminator().HasValue("Ucenik");
                });

            modelBuilder.Entity("EDnevnik.Models.Izostanak", b =>
                {
                    b.HasOne("EDnevnik.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EDnevnik.Models.Ucenik", "Ucenik")
                        .WithMany()
                        .HasForeignKey("UcenikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDnevnik.Models.Obavijest", b =>
                {
                    b.HasOne("EDnevnik.Models.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDnevnik.Models.ObavijestKorisnici", b =>
                {
                    b.HasOne("EDnevnik.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EDnevnik.Models.Obavijest", "Obavijest")
                        .WithMany()
                        .HasForeignKey("ObavijestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDnevnik.Models.Ocjena", b =>
                {
                    b.HasOne("EDnevnik.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EDnevnik.Models.Ucenik", "Ucenik")
                        .WithMany()
                        .HasForeignKey("UcenikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDnevnik.Models.Predmet", b =>
                {
                    b.HasOne("EDnevnik.Models.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDnevnik.Models.Razred", b =>
                {
                    b.HasOne("EDnevnik.Models.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDnevnik.Models.Ucenik", b =>
                {
                    b.HasOne("EDnevnik.Models.Razred", "Razred")
                        .WithMany()
                        .HasForeignKey("RazredId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EDnevnik.Models.Roditelj", "Roditelj")
                        .WithMany()
                        .HasForeignKey("RoditeljId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

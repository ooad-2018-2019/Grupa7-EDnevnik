using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDnevnik.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "Izostanak",
                columns: table => new
                {
                    IzostanakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UcenikId = table.Column<int>(nullable: false),
                    PredmetId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Opravdan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izostanak", x => x.IzostanakId);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ObavijestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    NastavnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ObavijestId);
                });

            migrationBuilder.CreateTable(
                name: "ObavijestKorisnici",
                columns: table => new
                {
                    ObavijestKorisniciId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnikId = table.Column<int>(nullable: false),
                    ObavijestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObavijestKorisnici", x => x.ObavijestKorisniciId);
                    table.ForeignKey(
                        name: "FK_ObavijestKorisnici_Obavijest_ObavijestId",
                        column: x => x.ObavijestId,
                        principalTable: "Obavijest",
                        principalColumn: "ObavijestId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    OcjenaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UcenikId = table.Column<int>(nullable: false),
                    PredmetId = table.Column<int>(nullable: false),
                    Vrijednost = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.OcjenaId);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    PredmetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Literatura = table.Column<string>(nullable: true),
                    NastavnikId = table.Column<int>(nullable: false),
                    Godina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.PredmetId);
                });

            migrationBuilder.CreateTable(
                name: "Razred",
                columns: table => new
                {
                    RazredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NastavnikId = table.Column<int>(nullable: false),
                    Broj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razred", x => x.RazredId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    PravoPristupa = table.Column<int>(nullable: false),
                    tip_korisnika = table.Column<string>(nullable: false),
                    RoditeljId = table.Column<int>(nullable: true),
                    RazredId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                    table.ForeignKey(
                        name: "FK_Korisnik_Razred_RazredId",
                        column: x => x.RazredId,
                        principalTable: "Razred",
                        principalColumn: "RazredId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_Korisnik_RoditeljId",
                        column: x => x.RoditeljId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izostanak_PredmetId",
                table: "Izostanak",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Izostanak_UcenikId",
                table: "Izostanak",
                column: "UcenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_RazredId",
                table: "Korisnik",
                column: "RazredId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_RoditeljId",
                table: "Korisnik",
                column: "RoditeljId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_NastavnikId",
                table: "Obavijest",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ObavijestKorisnici_KorisnikId",
                table: "ObavijestKorisnici",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ObavijestKorisnici_ObavijestId",
                table: "ObavijestKorisnici",
                column: "ObavijestId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_PredmetId",
                table: "Ocjena",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_UcenikId",
                table: "Ocjena",
                column: "UcenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Predmet_NastavnikId",
                table: "Predmet",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Razred_NastavnikId",
                table: "Razred",
                column: "NastavnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izostanak_Predmet_PredmetId",
                table: "Izostanak",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "PredmetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Izostanak_Korisnik_UcenikId",
                table: "Izostanak",
                column: "UcenikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_Korisnik_NastavnikId",
                table: "Obavijest",
                column: "NastavnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObavijestKorisnici_Korisnik_KorisnikId",
                table: "ObavijestKorisnici",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjena_Predmet_PredmetId",
                table: "Ocjena",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "PredmetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjena_Korisnik_UcenikId",
                table: "Ocjena",
                column: "UcenikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Predmet_Korisnik_NastavnikId",
                table: "Predmet",
                column: "NastavnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Razred_Korisnik_NastavnikId",
                table: "Razred",
                column: "NastavnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Razred_Korisnik_NastavnikId",
                table: "Razred");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Izostanak");

            migrationBuilder.DropTable(
                name: "ObavijestKorisnici");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Razred");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkladisteProizvodApi.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skladista",
                columns: table => new
                {
                    SkladisteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    Popunjeno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladista", x => x.SkladisteId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    ProizvodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kategorija = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkladisteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.ProizvodId);
                    table.ForeignKey(
                        name: "FK_Proizvodi_Skladista_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladista",
                        principalColumn: "SkladisteId");
                });

            migrationBuilder.CreateTable(
                name: "SkladisteProizvodi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkladisteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProizvodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkladisteProizvodi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkladisteProizvodi_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkladisteProizvodi_Skladista_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladista",
                        principalColumn: "SkladisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_SkladisteId",
                table: "Proizvodi",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_SkladisteProizvodi_ProizvodId",
                table: "SkladisteProizvodi",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_SkladisteProizvodi_SkladisteId",
                table: "SkladisteProizvodi",
                column: "SkladisteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkladisteProizvodi");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Skladista");
        }
    }
}

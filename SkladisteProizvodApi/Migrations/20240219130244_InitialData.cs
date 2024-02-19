using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkladisteProizvodApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "ProizvodId", "Cena", "ImageURL", "Kategorija", "Naziv", "SkladisteId" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 88000, "/images/placeholder.png", "Mobilni telefon", "Xiaomi Note 13 Pro", null },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 128000, "/images/placeholder.png", "Mobilni telefon", "Samsung Galaxy S24", null }
                });

            migrationBuilder.InsertData(
                table: "Skladista",
                columns: new[] { "SkladisteId", "Adresa", "Kapacitet", "Naziv", "Popunjeno" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Knjazevacka 16", 5000, "Gigatron Nis", 50 },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Nikole Pasica 10", 4200, "Gigatron Kragujevac", 0 }
                });

            migrationBuilder.InsertData(
                table: "SkladisteProizvodi",
                columns: new[] { "Id", "Kolicina", "ProizvodId", "SkladisteId" },
                values: new object[] { new Guid("d9ee9bd2-4311-4a63-830b-095c2a16f67d"), 50, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "ProizvodId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Skladista",
                keyColumn: "SkladisteId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "SkladisteProizvodi",
                keyColumn: "Id",
                keyValue: new Guid("d9ee9bd2-4311-4a63-830b-095c2a16f67d"));

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "ProizvodId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Skladista",
                keyColumn: "SkladisteId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));
        }
    }
}

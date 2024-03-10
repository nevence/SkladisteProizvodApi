using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkladisteProizvodApi.Migrations
{
    /// <inheritdoc />
    public partial class DodajIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SkladisteProizvodi",
                keyColumn: "Id",
                keyValue: new Guid("0b2b4a7b-e576-4541-8d1f-aef0e121909d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32ea7282-165a-43df-b160-1ff8f2df2161", null, "Administrator", "ADMINISTRATOR" },
                    { "801fe11e-126e-4161-af04-0d1544dab45b", null, "Menadzer", "MENADZER" },
                    { "b2aac1bc-c6fe-4c13-b8f4-60c3284710f3", null, "Zaposleni", "ZAPOSLENI" }
                });

            migrationBuilder.InsertData(
                table: "SkladisteProizvodi",
                columns: new[] { "Id", "Kolicina", "ProizvodId", "SkladisteId" },
                values: new object[] { new Guid("ba1d9fed-07c2-4d21-9a88-a71476eca269"), 50, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32ea7282-165a-43df-b160-1ff8f2df2161");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "801fe11e-126e-4161-af04-0d1544dab45b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2aac1bc-c6fe-4c13-b8f4-60c3284710f3");

            migrationBuilder.DeleteData(
                table: "SkladisteProizvodi",
                keyColumn: "Id",
                keyValue: new Guid("ba1d9fed-07c2-4d21-9a88-a71476eca269"));

            migrationBuilder.InsertData(
                table: "SkladisteProizvodi",
                columns: new[] { "Id", "Kolicina", "ProizvodId", "SkladisteId" },
                values: new object[] { new Guid("0b2b4a7b-e576-4541-8d1f-aef0e121909d"), 50, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });
        }
    }
}

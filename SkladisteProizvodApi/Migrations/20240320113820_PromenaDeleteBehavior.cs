using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkladisteProizvodApi.Migrations
{
    /// <inheritdoc />
    public partial class PromenaDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkladisteProizvodi_Proizvodi_ProizvodId",
                table: "SkladisteProizvodi");

            migrationBuilder.DropForeignKey(
                name: "FK_SkladisteProizvodi_Skladista_SkladisteId",
                table: "SkladisteProizvodi");

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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27c707ef-e8db-4fec-8fc3-5facb049dfc5", null, "Zaposleni", "ZAPOSLENI" },
                    { "a90d6d36-843f-43b6-a26c-42606e9e61ed", null, "Menadzer", "MENADZER" },
                    { "c716ea26-261b-4085-8bbb-9695ea666d83", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "SkladisteProizvodi",
                columns: new[] { "Id", "Kolicina", "ProizvodId", "SkladisteId" },
                values: new object[] { new Guid("da7911da-b2da-4a32-aa96-dfa644aa713c"), 50, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.AddForeignKey(
                name: "FK_SkladisteProizvodi_Proizvodi_ProizvodId",
                table: "SkladisteProizvodi",
                column: "ProizvodId",
                principalTable: "Proizvodi",
                principalColumn: "ProizvodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkladisteProizvodi_Skladista_SkladisteId",
                table: "SkladisteProizvodi",
                column: "SkladisteId",
                principalTable: "Skladista",
                principalColumn: "SkladisteId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkladisteProizvodi_Proizvodi_ProizvodId",
                table: "SkladisteProizvodi");

            migrationBuilder.DropForeignKey(
                name: "FK_SkladisteProizvodi_Skladista_SkladisteId",
                table: "SkladisteProizvodi");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c707ef-e8db-4fec-8fc3-5facb049dfc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a90d6d36-843f-43b6-a26c-42606e9e61ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c716ea26-261b-4085-8bbb-9695ea666d83");

            migrationBuilder.DeleteData(
                table: "SkladisteProizvodi",
                keyColumn: "Id",
                keyValue: new Guid("da7911da-b2da-4a32-aa96-dfa644aa713c"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_SkladisteProizvodi_Proizvodi_ProizvodId",
                table: "SkladisteProizvodi",
                column: "ProizvodId",
                principalTable: "Proizvodi",
                principalColumn: "ProizvodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkladisteProizvodi_Skladista_SkladisteId",
                table: "SkladisteProizvodi",
                column: "SkladisteId",
                principalTable: "Skladista",
                principalColumn: "SkladisteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

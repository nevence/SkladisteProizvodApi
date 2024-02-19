using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkladisteProizvodApi.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Skladista_SkladisteId",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_SkladisteId",
                table: "Proizvodi");

            migrationBuilder.DeleteData(
                table: "SkladisteProizvodi",
                keyColumn: "Id",
                keyValue: new Guid("d9ee9bd2-4311-4a63-830b-095c2a16f67d"));

            migrationBuilder.DropColumn(
                name: "SkladisteId",
                table: "Proizvodi");

            migrationBuilder.InsertData(
                table: "SkladisteProizvodi",
                columns: new[] { "Id", "Kolicina", "ProizvodId", "SkladisteId" },
                values: new object[] { new Guid("5156b79f-5ba3-4734-b30f-7592c231c432"), 50, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SkladisteProizvodi",
                keyColumn: "Id",
                keyValue: new Guid("5156b79f-5ba3-4734-b30f-7592c231c432"));

            migrationBuilder.AddColumn<Guid>(
                name: "SkladisteId",
                table: "Proizvodi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "ProizvodId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "SkladisteId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "ProizvodId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "SkladisteId",
                value: null);

            migrationBuilder.InsertData(
                table: "SkladisteProizvodi",
                columns: new[] { "Id", "Kolicina", "ProizvodId", "SkladisteId" },
                values: new object[] { new Guid("d9ee9bd2-4311-4a63-830b-095c2a16f67d"), 50, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_SkladisteId",
                table: "Proizvodi",
                column: "SkladisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Skladista_SkladisteId",
                table: "Proizvodi",
                column: "SkladisteId",
                principalTable: "Skladista",
                principalColumn: "SkladisteId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DosyaTakipSistemi.Migrations
{
    /// <inheritdoc />
    public partial class TemyizIstinaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IstinafTalebi",
                table: "Taraflar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TebligTarihi",
                table: "Taraflar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "TemyizTalebi",
                table: "Taraflar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IstinafTalebi",
                table: "Taraflar");

            migrationBuilder.DropColumn(
                name: "TebligTarihi",
                table: "Taraflar");

            migrationBuilder.DropColumn(
                name: "TemyizTalebi",
                table: "Taraflar");
        }
    }
}

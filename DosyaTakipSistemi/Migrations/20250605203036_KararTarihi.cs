using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DosyaTakipSistemi.Migrations
{
    /// <inheritdoc />
    public partial class KararTarihi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "KararTarihi",
                table: "Dosyalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KararTarihi",
                table: "Dosyalar");
        }
    }
}

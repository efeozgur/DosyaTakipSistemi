using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DosyaTakipSistemi.Migrations
{
    /// <inheritdoc />
    public partial class Kurulum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosyalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mahkeme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsasNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KararNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KararTebligTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarcDurumu = table.Column<bool>(type: "bit", nullable: false),
                    kararTur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taraflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarafTur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosyaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taraflar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taraflar_Dosyalar_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosyalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taraflar_DosyaId",
                table: "Taraflar",
                column: "DosyaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taraflar");

            migrationBuilder.DropTable(
                name: "Dosyalar");
        }
    }
}

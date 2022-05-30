using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    public partial class AcquistaRifornisci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acquista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    StrumentoMusicaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acquista_StrumentoMusicale_StrumentoMusicaleId",
                        column: x => x.StrumentoMusicaleId,
                        principalTable: "StrumentoMusicale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rifornisci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    StrumentoMusicaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rifornisci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rifornisci_StrumentoMusicale_StrumentoMusicaleId",
                        column: x => x.StrumentoMusicaleId,
                        principalTable: "StrumentoMusicale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acquista_StrumentoMusicaleId",
                table: "Acquista",
                column: "StrumentoMusicaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rifornisci_StrumentoMusicaleId",
                table: "Rifornisci",
                column: "StrumentoMusicaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acquista");

            migrationBuilder.DropTable(
                name: "Rifornisci");
        }
    }
}

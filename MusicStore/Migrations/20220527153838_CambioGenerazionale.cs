using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    public partial class CambioGenerazionale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrumentoMusicale_Fornitore_FornitoreId",
                table: "StrumentoMusicale");

            migrationBuilder.DropTable(
                name: "Fornitore");

            migrationBuilder.DropTable(
                name: "Utente");

            migrationBuilder.DropIndex(
                name: "IX_StrumentoMusicale_FornitoreId",
                table: "StrumentoMusicale");

            migrationBuilder.DropColumn(
                name: "FornitoreId",
                table: "StrumentoMusicale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FornitoreId",
                table: "StrumentoMusicale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fornitore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantità = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornitore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrumentoMusicaleId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantità = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utente_StrumentoMusicale_StrumentoMusicaleId",
                        column: x => x.StrumentoMusicaleId,
                        principalTable: "StrumentoMusicale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrumentoMusicale_FornitoreId",
                table: "StrumentoMusicale",
                column: "FornitoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Utente_StrumentoMusicaleId",
                table: "Utente",
                column: "StrumentoMusicaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StrumentoMusicale_Fornitore_FornitoreId",
                table: "StrumentoMusicale",
                column: "FornitoreId",
                principalTable: "Fornitore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

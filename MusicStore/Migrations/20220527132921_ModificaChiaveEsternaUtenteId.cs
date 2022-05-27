using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    public partial class ModificaChiaveEsternaUtenteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrumentoMusicale_Utente_UtenteId",
                table: "StrumentoMusicale");

            migrationBuilder.DropIndex(
                name: "IX_StrumentoMusicale_UtenteId",
                table: "StrumentoMusicale");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "StrumentoMusicale");

            migrationBuilder.RenameColumn(
                name: "quantità",
                table: "Utente",
                newName: "Quantità");

            migrationBuilder.AddColumn<int>(
                name: "StrumentoMusicaleId",
                table: "Utente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Utente_StrumentoMusicaleId",
                table: "Utente",
                column: "StrumentoMusicaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utente_StrumentoMusicale_StrumentoMusicaleId",
                table: "Utente",
                column: "StrumentoMusicaleId",
                principalTable: "StrumentoMusicale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utente_StrumentoMusicale_StrumentoMusicaleId",
                table: "Utente");

            migrationBuilder.DropIndex(
                name: "IX_Utente_StrumentoMusicaleId",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "StrumentoMusicaleId",
                table: "Utente");

            migrationBuilder.RenameColumn(
                name: "Quantità",
                table: "Utente",
                newName: "quantità");

            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "StrumentoMusicale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StrumentoMusicale_UtenteId",
                table: "StrumentoMusicale",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_StrumentoMusicale_Utente_UtenteId",
                table: "StrumentoMusicale",
                column: "UtenteId",
                principalTable: "Utente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

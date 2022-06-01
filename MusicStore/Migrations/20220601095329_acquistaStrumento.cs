using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    public partial class acquistaStrumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquista_StrumentoMusicale_StrumentoMusicaleId",
                table: "Acquista");

            migrationBuilder.AlterColumn<int>(
                name: "StrumentoMusicaleId",
                table: "Acquista",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "acquistaStrumento",
                columns: table => new
                {
                    nomeStrumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantitaAcquistata = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Acquista_StrumentoMusicale_StrumentoMusicaleId",
                table: "Acquista",
                column: "StrumentoMusicaleId",
                principalTable: "StrumentoMusicale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquista_StrumentoMusicale_StrumentoMusicaleId",
                table: "Acquista");

            migrationBuilder.DropTable(
                name: "acquistaStrumento");

            migrationBuilder.AlterColumn<int>(
                name: "StrumentoMusicaleId",
                table: "Acquista",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquista_StrumentoMusicale_StrumentoMusicaleId",
                table: "Acquista",
                column: "StrumentoMusicaleId",
                principalTable: "StrumentoMusicale",
                principalColumn: "Id");
        }
    }
}

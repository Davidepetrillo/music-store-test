using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    public partial class ModificheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrumentoMusicale_Categoria_CategoriaId",
                table: "StrumentoMusicale");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroLike",
                table: "StrumentoMusicale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "StrumentoMusicale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StrumentoMusicale_Categoria_CategoriaId",
                table: "StrumentoMusicale",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrumentoMusicale_Categoria_CategoriaId",
                table: "StrumentoMusicale");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroLike",
                table: "StrumentoMusicale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "StrumentoMusicale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StrumentoMusicale_Categoria_CategoriaId",
                table: "StrumentoMusicale",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

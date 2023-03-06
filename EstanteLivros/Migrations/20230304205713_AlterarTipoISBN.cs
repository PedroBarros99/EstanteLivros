using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstanteLivros.Migrations
{
    /// <inheritdoc />
    public partial class AlterarTipoISBN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "precoLivro",
                table: "Livros",
                newName: "PrecoLivro");

            migrationBuilder.RenameColumn(
                name: "nomeLivro",
                table: "Livros",
                newName: "NomeLivro");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Livros",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoLivro",
                table: "Livros",
                newName: "precoLivro");

            migrationBuilder.RenameColumn(
                name: "NomeLivro",
                table: "Livros",
                newName: "nomeLivro");

            migrationBuilder.AlterColumn<int>(
                name: "ISBN",
                table: "Livros",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstanteLivros.Migrations
{
    /// <inheritdoc />
    public partial class AdicioneiLivroAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Livros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_IDAutor",
                table: "Livros",
                column: "IDAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Autors_IDAutor",
                table: "Livros",
                column: "IDAutor",
                principalTable: "Autors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autors_IDAutor",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_IDAutor",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Livros");
        }
    }
}

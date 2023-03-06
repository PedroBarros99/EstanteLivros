using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstanteLivros.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoIndiceISBNValidacaoDePreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoLivro",
                table: "Livros",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,4)");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_ISBN",
                table: "Livros",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Livros_ISBN",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Livros");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoLivro",
                table: "Livros",
                type: "decimal(15,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstanteLivros.Migrations
{
    /// <inheritdoc />
    public partial class ApagarMyProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Livros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

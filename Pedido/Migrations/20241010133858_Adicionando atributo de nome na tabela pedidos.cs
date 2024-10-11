using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedido.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandoatributodenomenatabelapedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pedido",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pedido");
        }
    }
}

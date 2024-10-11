using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedido.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandoatributodefinalizadoatabeladepedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "finalizado",
                table: "Pedido",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finalizado",
                table: "Pedido");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedido.Migrations
{
    /// <inheritdoc />
    public partial class Corrigindoatabeladepedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "finalizado",
                table: "Pedido",
                newName: "Finalizado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Finalizado",
                table: "Pedido",
                newName: "finalizado");
        }
    }
}

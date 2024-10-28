using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedido.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandotributoquantidadeatabeladeitemPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantidade",
                table: "ItemPedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "ItemPedido");
        }
    }
}

using Pedido.Data.Dto.Produto;
using Pedido.Models;
using Pedido.Services;

namespace Pedido.Data.Dtos.ItemPedido;

public class ReadItemPedidoDto
{
	public int Id { get; set; }
	public int IdProduto { get; set; }

	public int PedidoId { get; set; }

	public int quantidade { get; set; }

	public ReadProdutoDto? Produto { get; set; } = null;
}

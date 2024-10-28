using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pedido.Data.Dtos.ItemPedido;

public class CreateItemPedidoDto
{
	public int IdProduto { get; set; }

	public int PedidoId { get; set; }

	public int quantidade { get; set; }

}

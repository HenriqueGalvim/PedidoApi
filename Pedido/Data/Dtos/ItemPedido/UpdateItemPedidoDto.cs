namespace Pedido.Data.Dtos.ItemPedido;

public class UpdateItemPedidoDto
{
	public int IdProduto { get; set; }

	public int? PedidoId { get; set; }

	public int quantidade { get; set; }
}

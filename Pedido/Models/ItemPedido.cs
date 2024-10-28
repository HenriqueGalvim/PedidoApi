using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pedido.Data.Dto.Produto;

namespace Pedido.Models;

public class ItemPedido
{
	[Key]
	[Required]
	public int Id { get; set; }

	[ForeignKey("Id")]
	public int PedidoId { get; set; }

	[Required]
	public int quantidade { get; set; }

	[Required]
	public int IdProduto { get; set; }

}

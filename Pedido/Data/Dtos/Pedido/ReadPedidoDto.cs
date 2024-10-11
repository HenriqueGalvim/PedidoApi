using System.ComponentModel.DataAnnotations;
using Pedido.Data.Dtos.ItemPedido;

namespace Pedido.Data.Dtos.Pedido;

public class ReadPedidoDto
{
	public int Id { get; set; }
	public virtual ICollection<ReadItemPedidoDto> ItemPedidos { get; set; }

	public DateTime DataPedido { get; set; } = DateTime.Now;

	public bool Finalizado { get; set; }

	public string Nome { get; set; }
}

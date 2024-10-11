using System.ComponentModel.DataAnnotations;
using Pedido.Data.Dtos.ItemPedido;
using Pedido.Models;

namespace Pedido.Data.Dtos.Pedido;

public class CreatedPedidoDto
{
	public string Nome { get; set; }

	public DateTime DataPedido { get; set; } = DateTime.Now;
}

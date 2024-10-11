using System.ComponentModel.DataAnnotations;

namespace Pedido.Models;

public class Pedido
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

	public virtual ICollection<ItemPedido> ItemPedidos { get; set; }

    public DateTime DataPedido { get; set; } = DateTime.Now;

    public bool Finalizado { get; set; } = false;
}

using Microsoft.EntityFrameworkCore;
using Pedido.Models;

namespace Pedido.Data;

public class PedidoDbContext : DbContext
{
	public PedidoDbContext(DbContextOptions<PedidoDbContext> opts) : base(opts)
	{

	}
	public DbSet<ItemPedido> ItemPedido { get; set; }
	public DbSet<Pedido.Models.Pedido> Pedido { get; set; }
}

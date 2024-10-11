using System.ComponentModel.DataAnnotations;

namespace Pedido.Models;

public class Produto
{

    public int Id { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public float PrecoUnitario { get; set; }

    public int Quantidade { get; set; }
}

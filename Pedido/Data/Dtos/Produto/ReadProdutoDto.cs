using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pedido.Data.Dto.Produto;

public class ReadProdutoDto
{
	[Key]
	[Required]
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[Required]
	[JsonPropertyName("nome")]
	public string Nome { get; set; }

	[Required]
	[JsonPropertyName("descricao")]
	public string Descricao { get; set; }

	[Required]
	[JsonPropertyName("precoUnitario")]
	public float PrecoUnitario { get; set; }

	[Required]
	[JsonPropertyName("quantidade")]
	public int Quantidade { get; set; }

}

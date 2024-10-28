using System.Text.Json;
using System.Text;
using Pedido.Data.Dto.Produto;
using Pedido.Data.Dtos.ItemPedido;
using Pedido.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Pedido.Services;

public class ItemServiceHttpClient : ControllerBase
{
	private readonly HttpClient _client;
	private readonly IConfiguration _configuration;

	public ItemServiceHttpClient(HttpClient client, IConfiguration configuration)
	{
		_client = client;
		_configuration = configuration;
	}

	public async Task<string> BuscaTodosProdutoNoEstoque()
	{
		try
		{
			using (HttpClient client = new HttpClient())
			{
				string resposta = await client.GetStringAsync("http://localhost:5153/Produto");

				return resposta;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erro: {ex.Message}");
			return null;
		}
	}

	public async Task<string> BuscaProdutoPorIdNoEstoque(int id)
	{
		try
		{
			using (HttpClient client = new HttpClient())
			{
				string resposta = await client.GetStringAsync("http://localhost:5153/Produto/" + id);

				return resposta;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erro: {ex.Message}");
			return null;
		}
	}

	public async Task<Boolean> VerificaQuantidadeItemNoEstoque(int idProduto, int itemPedidoQuantidade)
	{
		string resultado = await BuscaProdutoPorIdNoEstoque(idProduto);
		var deserializandoJson = System.Text.Json.JsonSerializer.Deserialize<ReadProdutoDto>(resultado);
		if (itemPedidoQuantidade > deserializandoJson.Quantidade)
		{
			return false;
		}
		else if (deserializandoJson.Quantidade == 0)
		{
			return false;
		}
		else if (itemPedidoQuantidade == 0)
		{
			return false;
		}
		var result = await AtualizaQuantidadeProdutoEstoque(idProduto,itemPedidoQuantidade);
		System.Console.WriteLine(resultado);
		return true;
	}
	public async Task<bool> AtualizaQuantidadeProdutoEstoque(int id, int quantidade)
	{
		try
		{
			System.Console.WriteLine("Entrei atualiza");
			string body = $"{quantidade}";

			var content = new StringContent(body, Encoding.UTF8, "application/json");
			using (HttpClient client = new HttpClient())
			{
				var resposta = await client.PutAsync("http://localhost:5153/Produto/quantidade/"+id, content);
				return true;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erro: {ex.Message}");
			return false;
		}
	}
}

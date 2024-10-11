using System.Text.Json;
using System.Text;
using Pedido.Data.Dto.Produto;
using Pedido.Data.Dtos.ItemPedido;
using Pedido.Models;
using Microsoft.AspNetCore.Mvc;

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
}

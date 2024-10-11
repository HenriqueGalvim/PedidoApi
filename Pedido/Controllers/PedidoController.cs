using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data.Dto.Produto;
using Pedido.Services;
using Pedido.Data.Dtos.ItemPedido;
using Pedido.Models;
using Pedido.Data.Dtos.Pedido;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
	private ItemServiceHttpClient _itemServiceHttpClient;
	private PedidoService _pedidoService;

	public PedidoController(ItemServiceHttpClient itemServiceHttpClient, PedidoService pedidoService)
	{
		_itemServiceHttpClient = itemServiceHttpClient;
		_pedidoService = pedidoService;
	}

	[HttpPost]
	public ActionResult CadastrarPedido([FromBody] CreatedPedidoDto createdPedidoDto)
	{
		Console.WriteLine(createdPedidoDto);
		return _pedidoService.CadastrarPedido(createdPedidoDto);
	}

	[HttpGet]
	public async Task<ActionResult> ListarPedidos([FromQuery] int skip = 0, [FromQuery] int take = 50)
	{
		return await _pedidoService.ListarPedidos(skip, take);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> ListarPedidoPorId(int id)
	{
		return await _pedidoService.ListarPedidoPorId(id);
	}

	[HttpPut("{id}")]
	public ActionResult AtualizarPedido(int id, [FromBody] UpdatePedidoDto updatePedidoDto)
	{
		Console.WriteLine(_pedidoService.AtualizarPedido(id, updatePedidoDto));
		return NoContent();
	}

	/* Deixar o delete pro final */

	[HttpGet("verificarProduto")]
	public async Task<ActionResult> VerificarProduto()
	{
		string resultado =  await _itemServiceHttpClient.BuscaTodosProdutoNoEstoque();
		var deserializandoJson = JsonSerializer.Deserialize<List<ReadProdutoDto>>(resultado);
		if (resultado == null)
		{
			return BadRequest("Erro ao retornar os produtos do estoque");
		}

		return Ok(deserializandoJson);
	}

	[HttpPost("finalizar")]
	public async Task<ActionResult> finalizarPedido([FromBody] int id)
	{
		var pedido = _pedidoService.ListarPedidoPorId(id);

		return Ok(pedido);
	}
}

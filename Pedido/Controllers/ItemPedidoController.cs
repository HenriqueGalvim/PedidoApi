using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pedido.Data.Dtos.Pedido;
using Pedido.Data;
using Pedido.Services;
using Pedido.Data.Dtos.ItemPedido;
using Microsoft.AspNetCore.Http.HttpResults;
using Pedido.Data.Dto.Produto;
using System.Text.Json;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemPedidoController : ControllerBase
{
	private ItemServiceHttpClient _itemServiceHttpClient;
	private ItemPedidoService _itemPedidoService;

	public ItemPedidoController(ItemServiceHttpClient itemServiceHttpClient, ItemPedidoService itemPedidoService)
	{
		_itemServiceHttpClient = itemServiceHttpClient;
		_itemPedidoService = itemPedidoService;
	}

	[HttpPost]
	public ActionResult CadastrarItemPedido([FromBody] CreateItemPedidoDto createItemPedidoDto)
	{
		Console.WriteLine(createItemPedidoDto);
		return _itemPedidoService.CadastrarItemPedido(createItemPedidoDto);
	}

	[HttpGet]
	public async Task<ActionResult> ListarItemPedido([FromQuery] int skip = 0, [FromQuery] int take = 50)
	{
		return await _itemPedidoService.ListarItemPedidos(skip,take);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> ListarPedidoPorId(int id)
	{
		return await _itemPedidoService.ListarItemPedidoPorId(id);
	}

	[HttpPut("{id}")]
	public ActionResult AtualizarPedido(int id, [FromBody] UpdateItemPedidoDto updateItemPedidoDto)
	{
		_itemPedidoService.AtualizarItemPedido(id, updateItemPedidoDto);
		return NoContent();
	}

	/* Deixar o delete pro final */

	[HttpGet("verificarProduto")]
	public async Task<ActionResult> VerificarProduto()
	{
		var resultado = await _itemServiceHttpClient.BuscaTodosProdutoNoEstoque();
		if (resultado == null)
		{
			return BadRequest("Erro ao fazer retornar dados do estoque");
		}

		return Ok(resultado);
	}
}

using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pedido.Data;
using Pedido.Data.Dto.Produto;
using Pedido.Data.Dtos.ItemPedido;
using Pedido.Data.Dtos.Pedido;
using Pedido.Models;

namespace Pedido.Services;

public class ItemPedidoService : ControllerBase
{
	private PedidoDbContext _context;
	private IMapper _mapper;
	private ItemServiceHttpClient _itemServiceHttpClient;

	public ItemPedidoService(PedidoDbContext context, IMapper mapper, ItemServiceHttpClient itemServiceHttpClient)
	{
		_context = context;
		_mapper = mapper;
		_itemServiceHttpClient = itemServiceHttpClient;
	}

	public ActionResult CadastrarItemPedido(CreateItemPedidoDto createItemPedidoDto)
	{
		if (verificaPedidoExiste(createItemPedidoDto.PedidoId))
		{
			ItemPedido itemPedido = _mapper.Map<ItemPedido>(createItemPedidoDto);
			_context.ItemPedido.Add(itemPedido);

			var pedido = getPedido(itemPedido.PedidoId);
			// Segundo passo, validar se o produto que deseja pedir, a quantidade é valida 
			// Só depois disso, cadastrar o item pedido no pedido
			pedido.ItemPedidos.Add(itemPedido);
			_context.SaveChanges();

			return Created();
		}

		return BadRequest("Erro em cadastrar Item Pedido");
	}
	public void AtualizarItemPedido(int id, UpdateItemPedidoDto updateItemPedidoDto)
	{
		var itemPedido = _context.ItemPedido.FirstOrDefault(itemPedido => itemPedido.Id == id)!;
		_mapper.Map(updateItemPedidoDto, itemPedido);
		_context.SaveChanges();
	}

	public async Task<ActionResult> ListarItemPedidoPorId(int id)
	{
		var itemPedido = _context.ItemPedido.FirstOrDefault(pedido => pedido.Id == id);

		if (itemPedido == null) return null;

		var itemPedidoDto = _mapper.Map<ReadItemPedidoDto>(itemPedido);

		string resultado = await _itemServiceHttpClient.BuscaProdutoPorIdNoEstoque(itemPedido.IdProduto);
		var deserializandoJson = JsonSerializer.Deserialize<ReadProdutoDto>(resultado);

		itemPedidoDto.Produto = deserializandoJson;

		return Ok(itemPedidoDto);
	}

	public async Task<ActionResult> ListarItemPedidos(int skip , int take)
	{

		string resultado = await _itemServiceHttpClient.BuscaTodosProdutoNoEstoque();
		var deserializandoJson = JsonSerializer.Deserialize<List<ReadProdutoDto>>(resultado);
		var itensPedidos = _mapper.Map<List<ReadItemPedidoDto>>(_context.ItemPedido.Skip(skip).Take(take));

		// Pulo do gato vetor abaixo
		foreach (var itemPedido in itensPedidos)
		{
			itemPedido.Produto = deserializandoJson.FirstOrDefault(produto => produto.Id == itemPedido.IdProduto);
		}

		return Ok(itensPedidos);

	}

	internal bool verificaPedidoExiste(int id)
	{
		var produto = _context.Pedido.FirstOrDefault(produto => produto.Id == id);

		if (produto is null)
		{
			return false;
		}

		return true;
	}

	internal Models.Pedido getPedido(int id)
	{
		var pedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
		if (pedido is null)
		{
			return null;
		}

		return pedido;
	}


}

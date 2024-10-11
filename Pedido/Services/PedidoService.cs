using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pedido.Data;
using Pedido.Data.Dto.Produto;
using Pedido.Data.Dtos.ItemPedido;
using Pedido.Data.Dtos.Pedido;
using Pedido.Models;

namespace Pedido.Services;

public class PedidoService : ControllerBase
{
	private PedidoDbContext _context;
	private IMapper _mapper;
	private ItemServiceHttpClient _itemServiceHttpClient;
	public PedidoService(PedidoDbContext context, IMapper mapper, ItemServiceHttpClient itemServiceHttpClient)
	{
		_context = context;
		_mapper = mapper;
		_itemServiceHttpClient = itemServiceHttpClient;
	}

	public ActionResult CadastrarPedido(CreatedPedidoDto createdPedidoDto)
	{
		Models.Pedido pedido = _mapper.Map<Models.Pedido>(createdPedidoDto);
		pedido.DataPedido = createdPedidoDto.DataPedido.ToUniversalTime();
		if (pedido is null)
		{
			return BadRequest("Erro ao criar pedido");
		}
		var resultado = _context.Pedido.Add(pedido);
		_context.SaveChanges();
		return Created();
	}


	public async Task<ActionResult> ListarPedidos(int skip = 0, int take = 50)
	{
		string resultado = await _itemServiceHttpClient.BuscaTodosProdutoNoEstoque();
		var deserializandoJson = JsonSerializer.Deserialize<List<ReadProdutoDto>>(resultado);
		var pedidos = _mapper.Map<List<ReadPedidoDto>>(_context.Pedido.Skip(skip).Take(take).ToList());

		// Pulo do gato vetor abaixo
		foreach (var pedido in pedidos)
		{
			foreach (var itemPedido in pedido.ItemPedidos)
			{
				 itemPedido.Produto = deserializandoJson.FirstOrDefault(produto => produto.Id == itemPedido.IdProduto);
			}
		}

		return Ok(pedidos);
	}


	public ReadPedidoDto ListarPedidoPorId(int id)
	{
		var produto = _context.Pedido.FirstOrDefault(produto => produto.Id == id);

		if (produto == null) return null;

		var produtoDto = _mapper.Map<ReadPedidoDto>(produto);
		return produtoDto;
	}

	public Models.Pedido AtualizarPedido(int id, UpdatePedidoDto updatePedidoDto)
	{
		Models.Pedido pedido = _context.Pedido.FirstOrDefault(produto => produto.Id == id)!;
		_mapper.Map(updatePedidoDto, pedido);
		_context.SaveChanges();

		return pedido;
	}
}

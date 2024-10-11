using AutoMapper;
using Pedido.Data.Dto.Produto;
using Pedido.Data.Dtos.ItemPedido;
using Pedido.Data.Dtos.Pedido;
using Pedido.Models;

namespace Pedido.Profiles;

public class ItemPedidoProfile : Profile
{
    public ItemPedidoProfile()
    {
		CreateMap<CreateItemPedidoDto, ItemPedido>();
		CreateMap<UpdateItemPedidoDto, ItemPedido>();
		CreateMap<ItemPedido, UpdateItemPedidoDto>();
		CreateMap<ItemPedido, ReadItemPedidoDto>();
	}
}

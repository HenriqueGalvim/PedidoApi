using AutoMapper;
using Pedido.Data.Dtos.Pedido;
using Pedido.Models;

namespace Pedido.Profiles;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
		CreateMap<CreatedPedidoDto, Models.Pedido>();
		CreateMap<UpdatePedidoDto, Models.Pedido>();
		CreateMap<Models.Pedido, UpdatePedidoDto>();
		CreateMap<Models.Pedido, ReadPedidoDto>();
	}
}

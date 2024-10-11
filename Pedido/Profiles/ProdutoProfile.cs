using AutoMapper;
using Pedido.Data.Dto.Produto;
using Pedido.Models;

namespace Pedido.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
		CreateMap<Produto, ReadProdutoDto>();
	}
}

using AutoMapper;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Produto;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Usuario;
using System.Collections.Generic;
using System.Linq;
using Model = GoodHealth.Domain.Usuario.Entities;
using ModelPrd = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.CrossCutting.Usuario.Mappings
{
    public class UsuarioDomainToDto : Profile
    {
        public UsuarioDomainToDto()
        {
            CreateMap<Model.Usuario, UsuarioDto>()
                .ForMember(dest => dest.NomeEmpresa, opt => opt.MapFrom(src => src.Empresa.Nome))
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa));

            CreateMap<Model.Usuario, UsuarioProdutoDto>()
                .ForMember(dest => dest.NomeEmpresa, opt => opt.MapFrom(src => src.Empresa.Nome))
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa))
                .ForMember(dest => dest.QtdDiasSemana, opt => opt.MapFrom(src => src.UsuarioProdutos.GroupBy(x => x.FlagDia).Count()))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.UsuarioProdutos.Sum(x => x.Produto.Valor)))
                .ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.UsuarioProdutos.Select(y => new ProdutoDto() {
                    Id = y.Produto.Id,
                    Descricao = y.Produto.Descricao,
                    FlagDia = y.FlagDia,
                    Valor = y.Produto.Valor,
                    DataInicio = y.DataInico,
                    DataFim = y.DataFim
                }).ToList()));
            
            CreateMap<PagedQuery<Model.Usuario>, PagedQueryList<UsuarioDto>>();
            CreateMap<PagedQuery<Model.Usuario>, PagedQueryList<UsuarioProdutoDto>>();
        }
    }
}

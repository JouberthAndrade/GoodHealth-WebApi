using AutoMapper;
using GoodHealth.Dto.Login;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Enum;
using GoodHealth.Shared.Produto;
using GoodHealth.Shared.Relatorios;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Usuario;
using System;
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
                .ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => AgruparPorDia(src.UsuarioProdutos)));

            CreateMap<Model.Usuario, LoginDto>();

            /*
            src.UsuarioProdutos.Select(y => new ProdutoDto() {
                Id = y.Produto.Id,
                Descricao = y.Produto.Descricao,
                FlagDia = y.FlagDia,
                DiaSemana = GetDescriptionDia(y.FlagDia),
                Valor = y.Produto.Valor,
                DataInicio = y.DataInico,
                DataFim = y.DataFim
            }).ToList()));*/

            CreateMap<Model.UsuarioProduto, PainelDto>()
                .ForMember(dest => dest.ProdutoId, opt => opt.MapFrom(src => src.ProdutoId))
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.Produto.Descricao))
                .ForMember(dest => dest.FlagDia, opt => opt.MapFrom(src => src.FlagDia))
                .ForMember(dest => dest.Classe, opt => opt.MapFrom(src => src.Produto.Classe))
                .ForMember(dest => dest.QtdDiaProduto, opt => opt.MapFrom(src => src.Quantidade));

            CreateMap<List<Model.UsuarioProduto>, List<UsuarioProdutoDto>>();
            CreateMap<PagedQuery<Model.Usuario>, PagedQueryList<UsuarioDto>>();
            CreateMap<PagedQuery<Model.Usuario>, PagedQueryList<UsuarioProdutoDto>>();
        }

        private List<ProdutoDto> AgruparPorDia(List<Model.UsuarioProduto> usuarioProdutos)
        {
            List<ProdutoDto> retorno = new List<ProdutoDto>();

            retorno = usuarioProdutos.GroupBy(x => x.FlagDia)
                        .Select(y => new ProdutoDto()
                        {
                            Id = y.FirstOrDefault().Produto.Id,
                            Descricao = y.FirstOrDefault().Produto.Descricao,
                            FlagDia = y.FirstOrDefault().FlagDia,
                            DiaSemana = GetDescriptionDia(y.FirstOrDefault().FlagDia),
                            Valor = y.FirstOrDefault().Produto.Valor,
                            DataInicio = y.FirstOrDefault().DataInico,
                            DataFim = y.FirstOrDefault().DataFim,
                            QtdNaSemana = y.Count()
                        }).ToList();

            return retorno;
        }

        private string GetDescriptionDia(string flagDia)
        {
            var enumValue = Enums.GetEnumValueFromDescription<DiaSemana>(flagDia);
            string retorno = "";
            switch (enumValue)
            {
                case DiaSemana.Segunda:
                    retorno = "Segunda-Feira";
                    break;
                case DiaSemana.Terca:
                    retorno = "Terça-Feira";
                    break;
                case DiaSemana.Quarta:
                    retorno = "Quarta-Feira";
                    break;
                case DiaSemana.Quinta:
                    retorno = "Quinta-Feira";
                    break;
                case DiaSemana.Sexta:
                    retorno = "Sexta-Feira";
                    break;
                case DiaSemana.Sabado:
                    retorno = "Sábado";
                    break;
                case DiaSemana.Domingo:
                    retorno = "Domingo";
                    break;
                default:
                    break;
            }
            return retorno;
        }
    }
}

using AutoMapper;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Usuario;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.CrossCutting.Usuario.Mappings
{
    public class UsuarioDomainToDto : Profile
    {
        public UsuarioDomainToDto()
        {
            CreateMap<Model.Usuario, UsuarioDto>()
                .ForMember(dest => dest.NomeEmpresa, opt => opt.MapFrom(src => src.Empresa.Nome))
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa));

            CreateMap<PagedQuery<Model.Usuario>, PagedQueryList<UsuarioDto>>();
        }
    }
}

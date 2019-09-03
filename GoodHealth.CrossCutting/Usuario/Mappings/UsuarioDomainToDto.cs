using AutoMapper;
using GoodHealth.Shared.Usuario;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.CrossCutting.Usuario.Mappings
{
    public class UsuarioDomainToDto : Profile
    {
        public UsuarioDomainToDto()
        {
            CreateMap<Model.Usuario, UsuarioDto>();
        }
    }
}

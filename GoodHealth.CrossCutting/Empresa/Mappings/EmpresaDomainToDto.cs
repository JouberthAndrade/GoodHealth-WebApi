using AutoMapper;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Empresa;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Usuario;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.CrossCutting.Empresa.Mappings  
{
    public class EmpresaDomainToDto : Profile
    {
        public EmpresaDomainToDto()
        {
            CreateMap<Model.Empresa, EmpresaDto>();
            CreateMap<PagedQuery<Model.Empresa>, PagedQueryList<EmpresaDto>>();
        }
            
    }
}

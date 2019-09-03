using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoodHealth.CroosCuttimg.Ioc;
using GoodHealth.Domain.Result;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.WebApi.Controllers.Usuario
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;

        public UsuarioController(IServiceProvider serviceProvider,
                                IValidationResultBuilder validationResultBuilder,
                                IMapper mapper) : base(validationResultBuilder)
        {
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ValidationResultModel<PagedQueryList>> GetAsync()
        {
            var usuarios = await serviceProvider.GetRequiredService<IUsuarioReadRepository>().FindAllPaged();
            var retorno = new PagedQueryList();

            retorno.Items = mapper.Map<List<UsuarioDto>>(usuarios.Items);
            retorno.TotalCount = usuarios.TotalCount;

            return await _validationResultBuilder.BuildAsync(retorno);
        }
    }
}
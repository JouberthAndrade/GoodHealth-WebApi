using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.WebApi.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;

        public UsuarioController(IServiceProvider serviceProvider
        , IMapper mapper) 
        {
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<UsuarioDto>> Obter()
        {
            var usuarios = serviceProvider.GetRequiredService<IUsuarioReadRepository>().FindAll().Result;

            var dto = mapper.Map<List<UsuarioDto>>(usuarios);

            return await Task.FromResult(dto.ToList());
        }
    }
}
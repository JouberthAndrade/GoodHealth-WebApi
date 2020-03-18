using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoodHealth.Application.Usuario.Commands;
using GoodHealth.Application.Usuario.Services.Interface;
using GoodHealth.CroosCuttimg.Ioc;
using GoodHealth.Domain.Result;
using GoodHealth.Dto.Login;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodHealth.WebApi.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;
        private readonly IHandler handler;
        private readonly IUsuarioService usuarioService;
        public LoginController(IServiceProvider serviceProvider,
                                IValidationResultBuilder validationResultBuilder,
                                IUsuarioService usuarioService,
                                IMapper mapper,
                                IHandler handler) : base(validationResultBuilder)
        {
            this.serviceProvider = serviceProvider;
            this.usuarioService = usuarioService;
            this.mapper = mapper;
            this.handler = handler;
        }

        [HttpPost("Logar")]
        [AllowAnonymous]
        public async Task<ValidationResultModel<LoginDto>> PostAsync([FromBody] LoginUsuarioCommand command)
        {
            var login = await this.usuarioService.Authenticate(command.Login, command.Senha);
            
            return await _validationResultBuilder.BuildAsync(login);
        }
    }
}
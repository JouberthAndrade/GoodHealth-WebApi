using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoodHealth.Application.Usuario.Commands;
using GoodHealth.CroosCuttimg.Ioc;
using GoodHealth.Domain.Result;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
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
        private readonly IHandler handler;

        public UsuarioController(IServiceProvider serviceProvider,
                                IValidationResultBuilder validationResultBuilder,
                                IMapper mapper,
                                IHandler handler) : base(validationResultBuilder)
        {
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
            this.handler = handler;
        }

        [HttpGet]
        public async Task<ValidationResultModel<PagedQueryList<UsuarioDto>>> GetAsync()
        {
            var usuarios = await serviceProvider.GetRequiredService<IUsuarioReadRepository>().FindAllPaged();
            var retorno = new PagedQueryList<UsuarioDto>();

            retorno.Items = mapper.Map<List<UsuarioDto>>(usuarios.Items);
            retorno.TotalCount = usuarios.TotalCount;

            return await _validationResultBuilder.BuildAsync(retorno);
        }
        [HttpGet("UsuarioProduto/{id}")]
        public async Task<ValidationResultModel<UsuarioProdutoDto>> GetUsuarioProduto(Guid id)
        {
            var retorno = await serviceProvider.GetRequiredService<IUsuarioReadRepository>().FindAsync(id);
            var dtoretorno =  mapper.Map<UsuarioProdutoDto>(retorno);

            return await _validationResultBuilder.BuildAsync(dtoretorno);
        }
        [HttpGet("UsuarioProduto")]
        public async Task<ValidationResultModel<PagedQueryList<UsuarioProdutoDto>>> GetAllUsuarioProduto()
        {
            var retorno = await serviceProvider.GetRequiredService<IUsuarioReadRepository>().FindUsuarioComProdutosAssociados();
            var dtoretorno = new PagedQueryList<UsuarioProdutoDto>();

            dtoretorno.Items = mapper.Map<List<UsuarioProdutoDto>>(retorno.Items);
            dtoretorno.TotalCount = retorno.TotalCount;

            return await _validationResultBuilder.BuildAsync(dtoretorno);
        }

        [HttpGet("{id}")]
        public async Task<ValidationResultModel<UsuarioDto>> GetById(Guid id)
        {
            var usuario = await serviceProvider.GetRequiredService<IUsuarioReadRepository>().FindAsync(id);
            var dto = mapper.Map<UsuarioDto>(usuario);

            return await _validationResultBuilder.BuildAsync(dto);
        }

        [HttpGet("{mes}/{ano}")]
        public async Task<ValidationResultModel<List<UsuarioDto>>> FilterByMonthAndYear(int mes, int ano)
        {
            var usuarios = await serviceProvider.GetRequiredService<IUsuarioReadRepository>().FilterByMonthAndYear(mes, ano);
            var dto = mapper.Map<List<UsuarioDto>>(usuarios);

            return await _validationResultBuilder.BuildAsync(dto);
        }

        [HttpPost]
        public async Task<ValidationResultModel<CommandResult>> PostAsync([FromBody] InserirEditarUsuarioCommand command)
        {
            var result = await handler.SendCommand<InserirEditarUsuarioCommand, CommandResult>(command);
            return await _validationResultBuilder.BuildAsync(result);
        }

        [HttpPut]
        public async Task<ValidationResultModel<CommandResult>> UpdateAsync([FromBody] InserirEditarUsuarioCommand command)
        {
            var result = await handler.SendCommand<InserirEditarUsuarioCommand, CommandResult>(command);
            return await _validationResultBuilder.BuildAsync(result);
        }

        [HttpDelete("{id}")]
        public async Task<ValidationResultModel<CommandResult>> Excluir([FromRoute]ExcluirUsuarioCommand command)
        {
            var cResult = await handler.SendCommand<ExcluirUsuarioCommand, CommandResult>(command);

            return await _validationResultBuilder.BuildAsync(cResult);
        }
    }
}
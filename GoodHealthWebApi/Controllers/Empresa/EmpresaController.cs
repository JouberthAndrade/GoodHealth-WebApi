using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoodHealth.Application.Empresa.Commands;
using GoodHealth.CroosCuttimg.Ioc;
using GoodHealth.Domain.Empresa.Repositories;
using GoodHealth.Domain.Result;
using GoodHealth.Domain.Empresa.Repositories;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Empresa;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Empresa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.WebApi.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : BaseController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;
        private readonly IHandler handler;

        public EmpresaController(IServiceProvider serviceProvider,
                                IValidationResultBuilder validationResultBuilder,
                                IMapper mapper,
                                IHandler handler) : base(validationResultBuilder)
        {
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
            this.handler = handler;
        }

        [HttpGet]
        public async Task<ValidationResultModel<PagedQueryList<EmpresaDto>>> GetAsync()
        {
            var empresas = await serviceProvider.GetRequiredService<IEmpresaReadRepository>().FindAllPaged();
            var retorno = new PagedQueryList<EmpresaDto>();

            retorno.Items = mapper.Map<List<EmpresaDto>>(empresas.Items);
            retorno.TotalCount = empresas.TotalCount;

            return await _validationResultBuilder.BuildAsync(retorno);
        }
        [HttpGet("{id}")]
        public async Task<ValidationResultModel<EmpresaDto>> GetById(Guid id)
        {
            var Empresa = await serviceProvider.GetRequiredService<IEmpresaReadRepository>().FindByIdAsync(id);
            var dto = mapper.Map<EmpresaDto>(Empresa);

            return await _validationResultBuilder.BuildAsync(dto);
        }

        [HttpPost]
        public async Task<ValidationResultModel<CommandResult>> PostAsync([FromBody] InserirEditarEmpresaCommand command)
        {
            var result = await handler.SendCommand<InserirEditarEmpresaCommand, CommandResult>(command);
            return await _validationResultBuilder.BuildAsync(result);
        }

        [HttpPut]
        public async Task<ValidationResultModel<CommandResult>> UpdateAsync([FromBody] InserirEditarEmpresaCommand command)
        {
            var result = await handler.SendCommand<InserirEditarEmpresaCommand, CommandResult>(command);
            return await _validationResultBuilder.BuildAsync(result);
        }

        [HttpDelete("{id}")]
        public async Task<ValidationResultModel<CommandResult>> Excluir([FromRoute]ExcluirEmpresaCommand command)
        {
            var cResult = await handler.SendCommand<ExcluirEmpresaCommand, CommandResult>(command);

            return await _validationResultBuilder.BuildAsync(cResult);
        }
    }
}
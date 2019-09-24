using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoodHealth.Application.Usuario.Commands;
using GoodHealth.CroosCuttimg.Ioc;
using GoodHealth.Domain.Produto.Repositories;
using GoodHealth.Domain.Result;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Relatorios;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHealth.WebApi.Controllers.PainelDeControle
{
    [Route("api/[controller]")]
    [ApiController]
    public class PainelController : BaseController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;
        private readonly IHandler handler;

        public PainelController(IServiceProvider serviceProvider, IMapper mapper, IHandler handler, IValidationResultBuilder validationResultBuilder) : base(validationResultBuilder)
        {
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
            this.handler = handler;
        }

        [HttpGet("{data}")]
        public async Task<ValidationResultModel<List<PainelDto>>> GetTotalProdutos(DateTime data)
        {
            var retorno = await serviceProvider.GetRequiredService<IUsuarioProdutoRepository>().FindByData(data);
            var dtoretorno = new List<PainelDto>();

            dtoretorno = mapper.Map<List<PainelDto>>(retorno);
            var grpRetorno = dtoretorno.GroupBy(x => x.ProdutoId).Select(x => new PainelDto() {
                ProdutoId = x.FirstOrDefault().ProdutoId,
                NomeProduto = x.FirstOrDefault().NomeProduto,
                FlagDia = x.FirstOrDefault().FlagDia,
                QtdDiaProduto = x.Count() * x.FirstOrDefault().QtdDiaProduto,
                Classe = x.FirstOrDefault().Classe
            }).ToList();
            

            return await _validationResultBuilder.BuildAsync(grpRetorno);
        }
    }
}
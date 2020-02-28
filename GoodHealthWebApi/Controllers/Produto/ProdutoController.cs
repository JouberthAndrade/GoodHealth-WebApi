using AutoMapper;
using GoodHealth.CroosCuttimg.Ioc;
using GoodHealth.Domain.Produto.Repositories;
using GoodHealth.Domain.Result;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Produto;
using GoodHealth.Shared.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodHealth.WebApi.Controllers.Produto
{
    [Route("api/[controller]")]
    public class ProdutoController : BaseController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;
        private readonly IHandler handler;

        public ProdutoController(IServiceProvider serviceProvider,
                                IValidationResultBuilder validationResultBuilder,
                                IMapper mapper,
                                IHandler handler) : base(validationResultBuilder)
        {
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
            this.handler = handler;
        }

        [HttpGet]
        public async Task<ValidationResultModel<PagedQueryList<ProdutoDto>>> GetAsync()
        {
            var produtos = await serviceProvider.GetRequiredService<IProdutoReadRepository>().GetAllAsync();
            var retorno = new PagedQueryList<ProdutoDto>();

            retorno.Items = mapper.Map<List<ProdutoDto>>(produtos);
            retorno.TotalCount = produtos.Count;

            return await _validationResultBuilder.BuildAsync(retorno);
        }



    }
}
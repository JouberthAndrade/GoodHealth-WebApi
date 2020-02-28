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
using GoodHealth.Shared.Produto;
using GoodHealth.Shared.Shared.Dto;
using GoodHealth.Shared.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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
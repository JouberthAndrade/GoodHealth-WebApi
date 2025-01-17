﻿using AutoMapper;
using GoodHealth.Shared.Produto;
using GoodHealth.Shared.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.CrossCutting.Produto.Mappings
{
    public class ProdutoDomainToDto : Profile
    {
        public ProdutoDomainToDto()
        {
            CreateMap<Model.Produto, ProdutoDto>();
        }
    }
}

using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Produto.Repositories;
using GoodHealth.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.Data.Pruduto.Repositories
{
    public class ProdutoReadRepository : EntityBaseRepository<Model.Produto, Guid>, IProdutoReadRepository
    {
        private readonly GlobalContext dbContext;
        public ProdutoReadRepository(GlobalContext dbcontext) : base(dbcontext)
        {
            this.dbContext = dbcontext;
        }
    }
}

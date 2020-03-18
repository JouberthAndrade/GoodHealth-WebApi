using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Produto.Repositories;
using GoodHealth.Shared.Data;
using System;
using Model = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.Data.Pruduto.Repositories
{
    public class ProdutoWriteRepository : EntityBaseRepository<Model.Produto, Guid>, IProdutoWriteRepository
    {
        public ProdutoWriteRepository(GlobalContext dbcontext) : base(dbcontext)
        {
        }
    }
}

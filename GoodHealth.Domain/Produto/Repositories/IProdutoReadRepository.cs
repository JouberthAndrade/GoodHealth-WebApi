using GoodHealth.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.Domain.Produto.Repositories
{
    public interface IProdutoReadRepository : IReadRepository<Model.Produto, Guid>
    {
        Task<List<Model.Produto>> FindByData(DateTime data);
    }
}

using GoodHealth.Shared.Interfaces;
using System;
using Model = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.Domain.Produto.Repositories
{
    public interface IProdutoWriteRepository : IWriteRepository<Model.Produto, Guid>
    {
    }
}

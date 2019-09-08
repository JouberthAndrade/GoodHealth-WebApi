using GoodHealth.Shared.Interfaces;
using System;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Domain.Empresa.Repositories
{
    public interface IEmpresaWriteRepository : IWriteRepository<Model.Empresa, Guid>
    {
    }
}

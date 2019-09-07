using GoodHealth.Shared.Data;
using GoodHealth.Shared.Interfaces;
using System;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Domain.Empresa.Repositories
{
    public interface IEmpresaReadRepository : IReadRepository<Model.Empresa, Guid>
    {
        Task<Model.Empresa> FindAsync(Guid id);
        Task<PagedQuery<Model.Empresa>> FindAllPaged();
    }
}

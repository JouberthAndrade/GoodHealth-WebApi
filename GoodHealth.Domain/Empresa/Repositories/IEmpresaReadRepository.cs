using GoodHealth.Shared.Shared.BaseRepository;
using System;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Domain.Empresa.Repositories
{
    public interface IEmpresaReadRepository : IReadRepository<Model.Empresa, Guid>
    {
        Task<Model.Empresa> FindAsync(Guid id);
    }
}

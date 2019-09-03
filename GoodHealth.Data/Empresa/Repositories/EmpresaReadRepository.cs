using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Empresa.Repositories;
using GoodHealth.Shared.Data;
using System;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Data.Empresa.Repositories
{
    public class EmpresaReadRepository : EntityBaseRepository<Model.Empresa, Guid>, IEmpresaReadRepository
    {
        public EmpresaReadRepository(GlobalContext dbcontext) : base(dbcontext)
        {
        }

        public Task<Model.Empresa> FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

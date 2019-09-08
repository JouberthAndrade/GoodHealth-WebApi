using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Empresa.Repositories;
using GoodHealth.Shared.Data;
using System;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Data.Empresa.Repositories
{
    public class EmpresaWriteRepository : EntityBaseRepository<Model.Empresa, Guid>, IEmpresaWriteRepository
    {
        public EmpresaWriteRepository(GlobalContext dbcontext) : base(dbcontext)
        {
        }
    }
}

using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Empresa.Repositories;
using GoodHealth.Shared.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Empresa.Entities;

namespace GoodHealth.Data.Empresa.Repositories
{
    public class EmpresaReadRepository : EntityBaseRepository<Model.Empresa, Guid>, IEmpresaReadRepository
    {
        public EmpresaReadRepository(GlobalContext dbcontext) : base(dbcontext)
        {
        }

        public Task<PagedQuery<Model.Empresa>> FindAllPaged()
        {
            var parameters = new PageParameters(int.MaxValue, 1);
            PagedQuery<Model.Empresa> retorno = new PagedQuery<Model.Empresa>();
            var query = Set
                         .OrderBy(x => x.Nome)
                      .AsQueryable();

            retorno.Items = query;
            retorno.TotalCount = query.Count();
            retorno.Page = parameters.Page;
            retorno.PageSize = parameters.PageSize;

            return Task.FromResult(retorno);
        }

        public Task<Model.Empresa> FindAsync(Guid id)
        {

            throw new NotImplementedException();
        }
    }
}

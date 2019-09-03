using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Data.Usuario.Repositories
{
    public class UsuarioReadRepository : EntityBaseRepository<Model.Usuario, Guid>, IUsuarioReadRepository
    {
        private readonly GlobalContext dbContext;
        public UsuarioReadRepository(GlobalContext dbcontext) : base(dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public Task<Model.Usuario> FindAsync(Guid id)
        {
            return Task.FromResult(
                Set.Include(x => x.Empresa)
                    .Where(x => x.Id == id).FirstOrDefault()
                );
        }

        public Task<List<Model.Usuario>> FindAll()
        {
            return Task.FromResult(
                Set.Include(x => x.Empresa)
                .OrderBy(x => x.Nome)
                .ToList());
        }

        public Task<PagedQuery<Model.Usuario>> FindAllPaged()
        {
            var query = Set
                            .OfType<Model.Usuario>()
                            .Include(x => x.Empresa)
                            .OrderBy(x => x.Nome)
                         .AsQueryable();


            var orderBy = this.GetOderExpression("nome", "ASC");

            return Task.FromResult(ApplyOrderFilterAndPagination(query, orderBy, null, new PageParameters(int.MaxValue, 1)));
        }

        private IEnumerable<OrderByOption<Model.Usuario>> GetOderExpression(string orderProperty, string orderType)
        {

            List<OrderByOption<Model.Usuario>> orderBy = new List<OrderByOption<Model.Usuario>>();
            var internalOrderType = orderType.ToLower() == "asc" ? OrderByType.Ascending : OrderByType.Descending;

            Expression<Func<Model.Usuario, object>> orderExpression = null;

            switch (orderProperty)
            {
                case "nome":
                    orderExpression = x => x.Nome;
                    break;
                case "empresa":
                    orderExpression = x => x.Empresa.Nome;
                    break;
               
            }

            orderBy.Add(new OrderByOption<Model.Usuario>(orderExpression, internalOrderType));

            return orderBy;
        }


        private PagedQuery<Model.Usuario> ApplyOrderFilterAndPagination(IQueryable<Model.Usuario> query, object orderBy, Expression<Func<Model.Usuario, bool>> condition, PageParameters parameters)
        {
            var returnObj = new PagedQuery<Model.Usuario>();
            returnObj.Page = parameters.Page;
            returnObj.PageSize = parameters.PageSize;


            ApplyFilter(ref query, condition);
           // ApplyOrder(ref query, orderBy);
            returnObj.TotalCount = query.Count();
           // ApplyPagination(ref query, parameters);
            returnObj.Items = query.AsEnumerable();

            return returnObj;
        }

        private void ApplyPagination(ref IQueryable<Model.Usuario> query, PageParameters parameters)
        {
            var skip = (parameters.Page * parameters.PageSize) - parameters.PageSize;
            query = query.Skip(skip).Take(parameters.PageSize);
        }

        private void ApplyFilter(ref IQueryable<Model.Usuario> query, Expression<Func<Model.Usuario, bool>> condition)
        {
            if (condition != null)
                query = query.Where(condition);
        }
    }
}

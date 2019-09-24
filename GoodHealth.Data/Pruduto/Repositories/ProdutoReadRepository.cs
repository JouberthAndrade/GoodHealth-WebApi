using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Produto.Repositories;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.Data.Pruduto.Repositories
{
    public class ProdutoReadRepository : EntityBaseRepository<Model.Produto, Guid>, IProdutoReadRepository
    {
        private readonly GlobalContext dbContext;
        public ProdutoReadRepository(GlobalContext dbcontext) : base(dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public Task<List<Model.Produto>> FindByData(DateTime data)
        {
            var flagDia = Enums.GetDescriptionFromEnumValue((DiaSemana)data.DayOfWeek);
            var query = Set
                        .OfType<Model.Produto>()
                        .Include(x => x.UsuarioProdutos)
                        .Where(x => x.UsuarioProdutos.Any(p => p.FlagDia.Equals(flagDia)))
                        .AsQueryable();

            var retorno = query.ToList();
            return Task.FromResult(retorno);
        }
    }
}

﻿using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Enum;
using GoodHealth.Shared.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;
using ModelPrd = GoodHealth.Domain.Produto.Entities;

namespace GoodHealth.Data.Usuario.Repositories
{
    public class UsuarioProdutoReadRepository : EntityBaseRepository<Model.UsuarioProduto, Guid>, IUsuarioProdutoRepository
    {
        private readonly GlobalContext dbContext;
        public UsuarioProdutoReadRepository(GlobalContext dbcontext) : base(dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public Task<Model.UsuarioProduto> FindUsuarioProduto()
        {
            var query = Set
                        .OfType<Model.UsuarioProduto>()
                        .Include(x => x.Usuario)
                        .ThenInclude(x => x.Empresa)
                        .Include(x => x.Produto)
                        .AsQueryable();

            var retorno = query.FirstOrDefault();
            return Task.FromResult(retorno);
        }

        public Task<List<Model.UsuarioProduto>> FindByData(DateTime data)
        {
            var flagDia = Enums.GetDescriptionFromEnumValue((DiaSemana)data.DayOfWeek.GetHashCode());
            var query = Set
                        .OfType<Model.UsuarioProduto>()
                        .Include(x => x.Produto)
                        .Include(x => x.Usuario)
                        .ThenInclude(x => x.Empresa)
                        .Where(p => p.FlagDia.Equals(flagDia))
                        .AsQueryable();

            var retorno = query.ToList();
            return Task.FromResult(retorno);
        }
    }
}

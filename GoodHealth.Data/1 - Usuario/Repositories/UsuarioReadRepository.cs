using GoodHealth.Data.Shared.Context;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.Shared.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Data.Usuario.Repositories
{
    public class UsuarioReadRepository : EntityBaseRepository<Model.Usuario, Guid>, IUsuarioReadRepository
    {
        public UsuarioReadRepository(GlobalContext dbcontext) : base(dbcontext)
        {
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
                Set.Include(x => x.Empresa).ToList());
        }


    }
}

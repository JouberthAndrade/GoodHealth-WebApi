using GoodHealth.Shared.Data;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Usuario;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Domain.Usuario.Repositories
{
    public interface IUsuarioReadRepository : IReadRepository<Model.Usuario, Guid>
    {
        Task<Model.Usuario> FindAsync(Guid id);
        Task<List<Model.Usuario>> FindAll();

        Task<PagedQuery<Model.Usuario>> FindAllPaged();
    }
}

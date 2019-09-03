using GoodHealth.Shared.Shared.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Domain.Usuario.Repositories
{
    public interface IUsuarioReadRepository : IReadRepository<Model.Usuario, Guid>
    {
        Task<Model.Usuario> FindAsync(Guid id);
        Task<List<Model.Usuario>> FindAll();
    }
}

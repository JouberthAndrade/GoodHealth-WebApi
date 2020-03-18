using GoodHealth.Shared.Data;
using GoodHealth.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;

namespace GoodHealth.Domain.Usuario.Repositories
{
    public interface IUsuarioReadRepository : IReadRepository<Model.Usuario, Guid>
    {
        Task<Model.Usuario> FindAsync(Guid id);
        Task<List<Model.Usuario>> FindAll();

        Task<PagedQuery<Model.Usuario>> FindAllPaged();

        Task<List<Model.Usuario>> FilterByMonthAndYear(int mes, int ano);

        Task<PagedQuery<Model.Usuario>> FindUsuarioComProdutosAssociados();

        Task<Model.Usuario> FindByLoginSenha(string login, string senha);

    }
}

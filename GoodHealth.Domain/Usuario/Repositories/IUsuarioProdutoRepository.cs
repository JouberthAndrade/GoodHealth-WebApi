using GoodHealth.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model = GoodHealth.Domain.Usuario.Entities;
using ModelPrd = GoodHealth.Domain.Produto.Entities;


namespace GoodHealth.Domain.Usuario.Repositories
{
    public interface IUsuarioProdutoRepository : IReadRepository<Model.UsuarioProduto, Guid>
    {
        Task<Model.UsuarioProduto> FindUsuarioProduto();
        Task<List<Model.UsuarioProduto>> FindByData(DateTime data);
    }
}

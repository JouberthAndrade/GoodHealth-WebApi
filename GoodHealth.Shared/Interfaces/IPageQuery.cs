using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Interfaces
{
    /// <summary>
    /// Interface que define o retorno de consultas paginadas
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IPageQuery<TEntity> : IPageParameters
    {
        IEnumerable<TEntity> Items { get; }

        int TotalCount { get; }

    }

    public interface IPageQueryAsync<TEntity> : IPageParameters
    {
        List<TEntity> Items { get; }

        Task<List<TEntity>> AsyncItems { set; }

        int TotalCount { get; }

    }
}

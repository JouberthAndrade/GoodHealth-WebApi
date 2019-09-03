using GoodHealth.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Shared.BaseRepository
{
    public interface IReadRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        IEnumerable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();
    }
}

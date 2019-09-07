using GoodHealth.Shared.Entitys;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Interfaces
{
    /// <summary>
    /// Interface wich define write repository operations
    /// </summary>
    /// <typeparam name="TEntity">Entity wich you want to work</typeparam>
    public interface IWriteRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        void Insert(TEntity entity);

        Task InsertAsync(TEntity entity);

        void Update(TEntity entity);

        void DetachedUpdate(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Delete(TPrimaryKey id);

        Task DeleteAsync(TPrimaryKey id);

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

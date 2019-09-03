using GoodHealth.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Shared.BaseRepository
{
    public class EntityBaseRepository<TEntity, TPrimaryKey> :
        IReadRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {

        protected DbContext Context { get; private set; }
        protected DbSet<TEntity> Set { get; private set; }
        public EntityBaseRepository(DbContext dbcontext)
        {
            Context = dbcontext;
            Set = Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = EF.CompileQuery<DbContext, IEnumerable<TEntity>>((DbContext db) => db.Set<TEntity>());
            return query(Context);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var query = EF.CompileAsyncQuery((DbContext db) => db.Set<TEntity>());
            return await query(Context).ToListAsync();
        }
    }
}

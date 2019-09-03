using Flunt.Validations;
using GoodHealth.Domain.Shared;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Shared.Entitys.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Data
{
    /// <summary>
    /// Classe que implementa as operações de repositorio base do entity framework
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityBaseRepository<TEntity, TPrimaryKey> :
        IWriteRepository<TEntity, TPrimaryKey>,
        IReadRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {

        protected DbContext Context { get; private set; }
        protected DbSet<TEntity> Set { get; private set; }

        public EntityBaseRepository(DbContext dbcontext)
        {
            Context = dbcontext;
            Set = Context.Set<TEntity>();
        }

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="entity">Entity wich you want delete</param>
        public virtual void Delete(TEntity entity)
        {
            if (entity is IDeletable)
            {
                var deletable = entity as IDeletable;
                deletable.Delete();
                Task.Run(() => UpdateAsync(entity));
            }
            else
            {
                Context.Entry(entity).State = EntityState.Deleted;
            }
        }

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="entity">Entity wich you want delete</param>
        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => this.Delete(entity));
        }

        /// <summary>
        /// Delete a entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        public void Delete(TPrimaryKey id)
        {
            var entity = Set.Find(id);
            this.Delete(entity);
        }

        /// <summary>
        /// Delete a entity by id async and by async way
        /// </summary>
        /// <param name="id">Entity Id</param>
        public async Task DeleteAsync(TPrimaryKey id)
        {
            await Task.Run(() => this.Delete(id));
        }

        /// <summary>
        /// Add New entity 
        /// </summary>
        /// <param name="entity">Entity wich you want to add</param>
        public virtual void Insert(TEntity entity)
        {
            Context.Add(entity);
        }

        /// <summary>
        /// Add New entity by async way
        /// </summary>
        /// <param name="entity">Entity wich you want to add</param>
        public async Task InsertAsync(TEntity entity)
        {
            await Task.Run(() => this.Insert(entity));
        }


        /// <summary>
        /// Change an entity
        /// </summary>
        /// <param name="entity">Entity wich you want to change</param>
        public virtual void Update(TEntity entity)
        {
            var local = Context.Set<TEntity>().Local?.FirstOrDefault(e => e.Id.Equals(entity.Id));
            if (local != null)
                Context.Entry(local).State = EntityState.Detached;

            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Change an entity by async way
        /// </summary>
        /// <param name="entity">Entity wich you want to change</param>
        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => this.Update(entity));
        }

        /// <summary>
        /// Return a entity filtering by id
        /// </summary>
        /// <param name="id">primary key wich entity wich you want retry</param>
        /// <returns></returns>
        public virtual TEntity FindById(TPrimaryKey id)
        {
            var query = EF.CompileQuery((DbContext db, TPrimaryKey internalId) => db.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(internalId)));
            return query(Context, id);
        }

        /// <summary>
        /// Return a entity filtering by id using async way
        /// </summary>
        /// <param name="id">primary key wich entity wich you want retry</param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdAsync(TPrimaryKey id)
        {
            var query = EF.CompileAsyncQuery((DbContext db, TPrimaryKey internalId) => db.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(internalId)));

            var result = await query(Context, id);

            return result;
        }

        /// <summary>
        /// Returns a collection of entities with possibility filtering and ordering
        /// </summary>
        /// <param name="condition"> Expression with a filter wich you want to aply </param>
        /// <param name="orderBy"> Collection with order options, can to add one or more order rules</param>
        /// <returns>Collection of filtered entities</returns>
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null)
        {
            var query = ApplyIncludes(includes);
            ApplyFilter(ref query, condition);
            ApplyOrder(ref query, orderBy);
            return query.AsEnumerable();
        }

        /// <summary>
        /// Returns a collection of entities with possibility filtering and ordering by async way
        /// </summary>
        /// <param name="condition"> Expression with a filter that you want to aply </param>
        /// <param name="orderBy"> Collection with order options, can to add one or more order rules</param>
        /// <returns>Collection of filtered entities</returns>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null)
        {
            var query = ApplyIncludes(includes);
            ApplyFilter(ref query, condition);
            ApplyOrder(ref query, orderBy);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Returns a object with a list of objects after order, filter and pagination and with pagination data (PageSize, Page) 
        /// </summary>
        /// <param name="parameters">Pagination parameters </param>
        /// <param name="condition">Expression with filter wich you want to aply</param>
        /// <param name="orderBy">Collection with order options, can to add one or more order rules</param>
        /// <returns>Collection of paginater and filtered entities</returns>
        public virtual PagedQuery<TEntity> Find(PageParameters parameters, Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null)
        {
            return ApplyOrderFilterAndPagination(ApplyIncludes(includes), orderBy, condition, parameters);
        }


        /// <summary>
        /// Returns a object with a list of objects after order, filter and pagination and with pagination data (PageSize, Page) by async way 
        /// </summary>
        /// <param name="parameters">Pagination parameters </param>
        /// <param name="condition">Expression with filter wich you want to aply</param>
        /// <param name="orderBy">Collection with order options, can to add one or more order rules</param>
        /// <returns>Collection of paginater and filtered entities</returns>
        public async Task<PagedQuery<TEntity>> FindAsync(PageParameters parameters, Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null)
        {
            return await ApplyOrderFilterAndPaginationAsync(ApplyIncludes(includes), orderBy, condition, parameters);
        }

        /// <summary>
        /// Returns a object with a list of objects after order, filter and pagination and with pagination data (PageSize, Page)
        /// </summary>
        /// <param name="parameters">Pagination parameters </param>
        /// <param name="orderBy">Collection with order options, can to add one or more order rules</param>
        /// <returns>Collection of paginater and filtered entities</returns>
        public virtual PagedQuery<TEntity> GetAll(PageParameters parameters, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null)
        {
            return ApplyOrderFilterAndPagination(ApplyIncludes(includes), orderBy, null, parameters);
        }

        /// <summary>
        /// Returns a object with a list of objects after order, filter and pagination and with pagination data (PageSize, Page) by async way
        /// </summary>
        /// <param name="parameters">Pagination parameters </param>
        /// <param name="orderBy">Collection with order options, can to add one or more order rules</param>
        /// <returns>Collection of paginater and filtered entities</returns>
        public async Task<PagedQuery<TEntity>> GetAllAsync(PageParameters parameters, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null)
        {
            return await ApplyOrderFilterAndPaginationAsync(ApplyIncludes(includes), orderBy, null, parameters);
        }

        /// <summary>
        /// Returns all of the objects from repository
        /// 
        /// PAY ATTENTION - You shouldn't use this method if you want apply any filter after get results
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = EF.CompileQuery<DbContext, IEnumerable<TEntity>>((DbContext db) => db.Set<TEntity>());
            return query(Context);
        }

        /// <summary>
        /// Returns all of the objects from repository using async way
        /// 
        /// PAY ATTENTION - You shouldn't use this method if you want apply any filter after get results 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            var query = EF.CompileAsyncQuery((DbContext db) => db.Set<TEntity>());
            return await query(Context).ToListAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return Set.AsQueryable();
        }

        private IQueryable<TEntity> ApplyIncludes(IEnumerable<Expression<Func<TEntity, object>>> includes)
        {
            var query = Set.AsQueryable();
            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }


        private PagedQuery<TEntity> ApplyOrderFilterAndPagination(IQueryable<TEntity> query,
                                                                  IEnumerable<OrderByOption<TEntity>> orderBy,
                                                                  Expression<Func<TEntity, bool>> condition,
                                                                  PageParameters parameters)
        {
            var returnObj = new PagedQuery<TEntity>
            {
                Page = parameters.Page,
                PageSize = parameters.PageSize
            };

            ApplyFilter(ref query, condition);
            ApplyOrder(ref query, orderBy);
            returnObj.TotalCount = query.Count();
            ApplyPagination(ref query, parameters);
            returnObj.Items = query.AsEnumerable();

            return returnObj;
        }

        private async Task<PagedQuery<TEntity>> ApplyOrderFilterAndPaginationAsync(IQueryable<TEntity> query,
                                                                  IEnumerable<OrderByOption<TEntity>> orderBy,
                                                                  Expression<Func<TEntity, bool>> condition,
                                                                  PageParameters parameters)
        {
            var returnObj = new PagedQuery<TEntity>
            {
                Page = parameters.Page,
                PageSize = parameters.PageSize
            };

            ApplyFilter(ref query, condition);
            ApplyOrder(ref query, orderBy);
            var countTask = query.CountAsync();
            ApplyPagination(ref query, parameters);
            var itemsTask = query.ToListAsync();

            await Task.WhenAll(countTask, itemsTask);

            returnObj.TotalCount = await countTask;
            returnObj.Items = (await itemsTask).AsEnumerable();

            return returnObj;
        }

        private void ApplyPagination(ref IQueryable<TEntity> query, PageParameters parameters)
        {
            var skip = (parameters.Page - 1) * parameters.PageSize;
            query = query.Skip(skip).Take(parameters.PageSize);
        }

        private void ApplyFilter(ref IQueryable<TEntity> query, Expression<Func<TEntity, bool>> condition)
        {
            if (condition != null)
                query = query.Where(condition);
        }

        private void ApplyOrder(ref IQueryable<TEntity> query, IEnumerable<OrderByOption<TEntity>> orderBy)
        {
            if (orderBy != null)
            {
                foreach (var rule in orderBy)
                {
                    if (rule.OrderType == OrderByType.Ascending)
                        query = query.OrderBy(rule.OrderProperty);
                    else
                        query = query.OrderByDescending(rule.OrderProperty);
                }
            }
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(this.SaveChanges());
        }

        public void DetachedUpdate(TEntity entity)
        {
            var local = this.Set.Local.FirstOrDefault();

            Context.Entry(local).State = EntityState.Detached;

            Context.Entry(entity).State = EntityState.Modified;
        }

    }

    
}

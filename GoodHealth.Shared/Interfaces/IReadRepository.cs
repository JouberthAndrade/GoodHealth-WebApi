using Flunt.Validations;
using GoodHealth.Shared.Data;
using GoodHealth.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Interfaces
{
    /// <summary>
    /// Interface wich define read repository operations
    /// </summary>
    /// <typeparam name="TEntity">Entity wich you want to work</typeparam>
    public interface IReadRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {

        TEntity FindById(TPrimaryKey id);

        Task<TEntity> FindByIdAsync(TPrimaryKey id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null);

        PagedQuery<TEntity> Find(PageParameters parameters, Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null);

        Task<PagedQuery<TEntity>> FindAsync(PageParameters parameters, Expression<Func<TEntity, bool>> condition, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null);

        IEnumerable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        PagedQuery<TEntity> GetAll(PageParameters parameters, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null);

        Task<PagedQuery<TEntity>> GetAllAsync(PageParameters parameters, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<OrderByOption<TEntity>> orderBy = null);

        IQueryable<TEntity> Query();
    }
}
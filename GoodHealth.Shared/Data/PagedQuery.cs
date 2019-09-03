using GoodHealth.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Data
{
    /// <summary>
    /// Class wich implements the return os paginated queries
    /// </summary>
    /// <typeparam name="TEntity">Entity wich you want to work</typeparam>
    public class PagedQuery<TEntity> : IPageQuery<TEntity>
    {
        /// <summary>
        /// List with result os paginated queries
        /// </summary>
        public IEnumerable<TEntity> Items { get; set; }

        /// <summary>
        /// Page size data
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page required
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Total amount of paginated items
        /// </summary>
        public int TotalCount { get; set; }
    }

    public class PagedQueryAsync<TEntity> : IPageQueryAsync<TEntity>
    {
        /// <summary>
        /// List with result os paginated queries
        /// </summary>
        /// 
        public Task<List<TEntity>> AsyncItems
        {
            private get;
            set;
        }
        public List<TEntity> Items {
            get
            {
                return AsyncItems.Result;
            }
        }

        /// <summary>
        /// Page size data
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page required
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Total amount of paginated items
        /// </summary>
        public int TotalCount { get; set; }
    }
}

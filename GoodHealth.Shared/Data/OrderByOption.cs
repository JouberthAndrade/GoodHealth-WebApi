using System;
using System.Linq.Expressions;

namespace GoodHealth.Shared.Data
{
    /// <summary>
    /// Class wich implements the ordering options
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class OrderByOption<TEntity>
    {
        /// <summary>
        /// Property wich you want to order
        /// </summary>
        public Expression<Func<TEntity, object>> OrderProperty { get; set; }

        /// <summary>
        /// Order direction (Ascending, Descending)
        /// </summary>
        public OrderByType OrderType { get; set; }

        public OrderByOption(Expression<Func<TEntity, object>> orderProperty, OrderByType orderType)
        {
            OrderProperty = orderProperty;
            OrderType = orderType;
        }

    }
}

using GoodHealth.Shared.Interfaces;

namespace GoodHealth.Shared.Data
{
    /// <summary>
    /// Class wich implements paginating query parameters
    /// </summary>
    public class PageParameters : IPageParameters
    {
        /// <summary>
        /// Page size wich you want to get
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Current page wich you want to get
        /// </summary>
        public int Page { get; set; }

        public PageParameters(int pagesize, int page)
        {
            PageSize = pagesize;
            Page = page;
        }
    }
}

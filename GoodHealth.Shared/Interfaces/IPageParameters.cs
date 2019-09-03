namespace GoodHealth.Shared.Interfaces
{
    /// <summary>
    /// Interface wich define paginated query parameters
    /// </summary>
    public interface IPageParameters
    {
        int PageSize { get; set; }
        int Page { get; set; }
    }
}

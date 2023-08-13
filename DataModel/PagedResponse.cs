/// <summary>
/// Paged Response - Used to return a paged response from the API
/// </summary>
/// <typeparam name="T">
/// Generic type of response that will be stored on an individual record basis
/// </typeparam>
public class PagedResponse<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public required List<T> Data { get; set; }
}
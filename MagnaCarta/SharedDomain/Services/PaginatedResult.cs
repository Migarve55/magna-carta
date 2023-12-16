namespace SharedDomain.Services;

public class PaginatedResult<T> where T : class
{
    public PaginatedResult(IReadOnlyCollection<T> result, int currentPage, int pages)
    {
        Result = result;
        CurrentPage = currentPage;
        Pages = pages;
    }

    public IReadOnlyCollection<T> Result { get; }
    
    public int CurrentPage { get; }
    
    public int Pages { get; }

    public static PaginatedResult<T> ToPaginatedResult(IReadOnlyCollection<T> result, int page, int perPage)
    {
        int total = result.Count;
        int totalPages = (int)Math.Ceiling(total / (double)perPage);
        var paginatedResult = result
            .Skip(perPage * (page - 1))
            .Take(perPage)
            .ToList();
        return new PaginatedResult<T>(paginatedResult, page, totalPages);
    }
}
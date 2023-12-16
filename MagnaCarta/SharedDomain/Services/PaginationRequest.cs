namespace SharedDomain.Services;

public class PaginationRequest
{
    public PaginationRequest(int page)
    {
        Page = page;
    }
    
    public int PerPage { get; set; } = 10;

    public int Page { get; }
}
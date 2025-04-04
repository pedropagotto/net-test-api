namespace Authentication.Domain.Abstractions;

public abstract class PaginationRequest
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 25;
}

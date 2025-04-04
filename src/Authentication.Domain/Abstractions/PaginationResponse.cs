namespace Authentication.Domain.Abstractions;

public class PaginateResponse<T>(T data, int page, int pageSize, int totalRows)
{
    public T Data { get; private set; } = data;
    public int Page { get; private set; } = page;
    public int PageSize { get; private set; } = pageSize;
    public int TotalRows { get; private set; } = totalRows;
}

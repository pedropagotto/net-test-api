namespace Authentication.Domain.Extensions;

public static class PaginateExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> collection, int page, int pageSize)
    {
        var skipCount = CalculateSkipCount(page, pageSize);
        return collection.Skip(skipCount).Take(pageSize);
    }

    public static IEnumerable<T> Paginate<T>(this IOrderedEnumerable<T> collection, int page, int pageSize)
    {
        var skipCount = CalculateSkipCount(page, pageSize);
        return collection.Skip(skipCount).Take(pageSize);
    }

    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> collection, int page, int pageSize)
    {
        var skipCount = CalculateSkipCount(page, pageSize);
        return collection.Skip(skipCount).Take(pageSize);
    }

    public static List<T> PaginateList<T>(this List<T> collection, int page, int pageSize)
    {
        var skipCount = CalculateSkipCount(page, pageSize);
        return collection.Skip(skipCount).Take(pageSize).ToList();
    }

    private static int CalculateSkipCount(int page, int pageSize)
    {
        return pageSize * (page - 1);
    }
}

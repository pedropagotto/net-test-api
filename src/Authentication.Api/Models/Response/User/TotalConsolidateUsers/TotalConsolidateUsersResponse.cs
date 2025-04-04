using Authentication.Application.User.TotalConsolidateUsers;

namespace Authentication.Api.Models.Response.User.TotalConsolidateUsers;

public class TotalConsolidateUsersResponse
{
    public TotalConsolidateUsersResponse(List<TotalConsolidateUserItemResponse> data)
    {
        Data = data;
    }
    public List<TotalConsolidateUserItemResponse> Data { get; set; }

    public static TotalConsolidateUsersResponse Map(TotalConsolidateUsersResult result)
    {
        var items = result.Data
            .Select(item => new TotalConsolidateUserItemResponse().Map(item)).ToList();
        return new TotalConsolidateUsersResponse(items);
    }
}

public class TotalConsolidateUserItemResponse
{
    public int Total {get; set;}
    
    public string Description {get; set;}

    public TotalConsolidateUserItemResponse Map(TotalConsolidateUserItem item) => new()
    {
        Total = item.Total,
        Description = item.Description
    };
}
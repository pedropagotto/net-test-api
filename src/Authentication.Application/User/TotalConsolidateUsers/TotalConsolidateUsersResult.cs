using Authentication.Domain.Repositories.Projections;

namespace Authentication.Application.User.TotalConsolidateUsers;

public class TotalConsolidateUsersResult
{
    public TotalConsolidateUsersResult(List<TotalConsolidateUserItem> data)
    {
        Data = data;
    }
    public List<TotalConsolidateUserItem> Data { get; set; }
}

public class TotalConsolidateUserItem
{
    public int Total {get; set;}
    
    public string Description {get; set;}

    public TotalConsolidateUserItem Map(TotalConsolidateUserItemProjection projection) => new()
    {
        Total = projection.Total,
        Description = projection.Description
    };
}

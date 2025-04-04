using Authentication.Domain.Abstractions;
using Authentication.Domain.Enums;
using Authentication.Domain.ValueObjects;

namespace Authentication.Domain.Entities;

public class User : BaseAudit, IAggregateRoot
{
    private User()
    {
    }

    public User(string name, string email, string password, string otherInfo, string interests, string feelings, string valuesDescription)
    {
        Name = name;
        OtherInfo = otherInfo;
        Interests = interests;
        Feelings = feelings;
        ValuesDescription = valuesDescription;
        SetStatusPending();
        SetAuthentication(email, password);
    }
    public string Name { get; private set; }

    public int? Age { get; private set; }

    public string? Address { get; private set; }

    public EUserStatus Status { get; private set; }

    public string OtherInfo { get; private set; }

    public string Interests { get; private set; }

    public string Feelings { get; private set; }

    public string ValuesDescription { get; private set; }

    public int AuthenticationId { get; private set; }
    public virtual Auth Authentication { get; private set; }

    public User SetAuthentication(string email, string password)
    {
        Authentication = new Auth(new Email(email), password);
        return this;
    }
    
    public User SetAuthenticationId(int authenticationId)
    {
        AuthenticationId = authenticationId;
        return this;
    }


    public User SetName(string name)
    {
        Name = name;
        return this;
    }

    public User SetAge(int? age)
    {
        Age = age;
        return this;
    }

    public User SetAddress(string? address)
    {
        Address = address;
        return this;
    }

    public User SetStatus(EUserStatus status)
    {
        Status = status;
        return this;
    }

    public User SetOtherInfo(string otherInfo)
    {
        OtherInfo = otherInfo;
        return this;
    }

    public User SetInterests(string interests)
    {
        Interests = interests;
        return this;
    }

    public User SetFeelings(string feelings)
    {
        Feelings = feelings;
        return this;
    }

    public User SetValuesDescription(string values)
    {
        ValuesDescription = values;
        return this;
    }

    public User SetStatusInactive()
    {
        Status = EUserStatus.INACTIVE;
        return this;
    }

    public User SetStatusActive()
    {
        Status = EUserStatus.ACTIVE;
        return this;
    }

    public User SetStatusPending()
    {
        Status = EUserStatus.ACTIVE;
        return this;
    }
}

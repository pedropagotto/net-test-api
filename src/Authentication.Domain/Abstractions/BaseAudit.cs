namespace Authentication.Domain.Abstractions;

public abstract class BaseAudit : BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public string? UpdatedBy { get; set; } = string.Empty;
}

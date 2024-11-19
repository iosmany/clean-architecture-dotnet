namespace ecommerce.domain;

public abstract class AuditEntity : Entity<long>
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
}

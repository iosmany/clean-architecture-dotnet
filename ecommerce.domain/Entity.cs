namespace ecommerce.domain;

public interface IEntity<K>
{
    K Id { get; }
}

public abstract class Entity<K> : IEntity<K> where K : notnull
{
    public K Id { get; private set; }

    protected Entity()
    {
    }
    protected Entity(K id) : this()
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (!(obj is Entity<K> other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetRealType() != other.GetRealType())
            return false;

        var def = default(K);
        if (Id.Equals(def) || other.Id.Equals(def))
            return false;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<K> a, Entity<K> b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }

    public static bool operator !=(Entity<K> a, Entity<K> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return ((GetRealType()?.ToString() ?? string.Empty) + Id).GetHashCode();
    }

    /// <summary>
    /// Retrieve the real type of the entity
    /// </summary>
    /// <returns></returns>
    private Type? GetRealType()
    {
        Type type = GetType();
        if (type.ToString().Contains("Castle.Proxies.")) //because of lazy loading, EF utilize proxies
            return type.BaseType;
        return type;
    }
}



namespace ecommerce.domain.Entities.Core;
public class Country : Entity<string>
{
    public string Name { get; private set; }

    private Country() : base() { }

    internal Country(string id, string name) : base(id)
    {
        Name = name;
    }
}

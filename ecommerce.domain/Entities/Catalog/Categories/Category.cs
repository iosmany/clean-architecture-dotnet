namespace ecommerce.domain.Entities.Catalog.Categories;

public class Category : AuditEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    /// <summary>
    /// Image url
    /// </summary>
    public string? Image { get; private set; }
    public virtual Category? Parent { get; private set; }

    protected Category()
    {
    }

    internal Category(string name, string description, string? image = null, Category? parent = null)
    {
        Name = name;
        Description = description;
        Image = image;
        Parent = parent;
    }

    public void Update(string name, string description, Category? parent)
    {
        Name = name;
        Description = description;
        Parent = parent;
    }

    public void ChangeImage(string image)
    {
        Image = image;
    }
}

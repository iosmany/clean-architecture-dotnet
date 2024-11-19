

namespace ecommerce.domain.Entities.Categories;

public class Category: AuditEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public virtual Category? Parent { get; private set; }

    protected Category()
    {
    }

    private Category(string name, string description, string image, Category? parent = null)
    {
        Name = name;
        Description = description;
        Image = image;
        Parent = parent;
    }

    public static Category Create(string name, string description, string image, Category? parent)
    {
        return new Category(name, description, image, parent);
    }

    public void Update(string name, string description, string image, Category? parent)
    {
        Name = name;
        Description = description;
        Image = image;
        Parent = parent;
    }
}

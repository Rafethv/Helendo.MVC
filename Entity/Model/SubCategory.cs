using Entity.Base;
using Entity.Entity;

namespace Entity.Model;

public class SubCategory : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public Category? Category { get; set; }
    public List<Product>? Products { get; set; }
}

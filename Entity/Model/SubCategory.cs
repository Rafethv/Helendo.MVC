using Entity.Base;
using Entity.Entity;

namespace Entity.Model;

public class SubCategory : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<Product>? Products { get; set; }
}

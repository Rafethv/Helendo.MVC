using Entity.Base;
using Entity.Entity;

namespace Entity.Model;

public class ProductDetail : BaseEntity, IEntity
{
    public string? Description { get; set; }
    public double Weight { get; set; }
    public Product? Product { get; set; }
}

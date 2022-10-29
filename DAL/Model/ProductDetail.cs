using DAL.Base;
using DAL.Entity;

namespace DAL.Model;

public class ProductDetail : BaseEntity, IEntity
{
    public string? Description { get; set; }
    public double Weight { get; set; }
    public Product? Product { get; set; }
}

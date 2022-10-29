using DAL.Base;
using DAL.Entity;

namespace DAL.Model;

public class Tag : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}

using Entity.Base;
using Entity.Entity;

namespace Entity.Model;

public class Tag : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}

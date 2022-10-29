using Entity.Base;
using Entity.Entity;
using Entity.Identity;

namespace Entity.Model;

public class Cart : BaseEntity, IEntity
{
    public int TotalPrice { get; set; }
    public AppUser? User { get; set; }
    public ICollection<Product>? Products { get; set; }
}

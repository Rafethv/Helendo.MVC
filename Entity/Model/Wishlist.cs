using Entity.Base;
using Entity.Entity;
using Entity.Identity;

namespace Entity.Model;

public class Wishlist : BaseEntity, IEntity
{
    public AppUser? User { get; set; }
    public ICollection<Product>? Products { get; set; }
}

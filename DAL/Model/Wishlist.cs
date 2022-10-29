using DAL.Base;
using DAL.Entity;
using DAL.Identity;

namespace DAL.Model;

public class Wishlist : BaseEntity, IEntity
{
    public AppUser? User { get; set; }
    public ICollection<Product>? Products { get; set; }
}

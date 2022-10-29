using DAL.Base;
using DAL.Entity;
using DAL.Identity;

namespace DAL.Model;

public class Cart : BaseEntity, IEntity
{
    public int TotalPrice { get; set; }
    public AppUser? User { get; set; }
    public ICollection<Product>? Products { get; set; }
}

using DAL.Base;
using DAL.Entity;
using DAL.Identity;

namespace DAL.Model;

public class Product : BaseEntity, IEntity
{
    public string? Title { get; set; }
    public double Price { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public int ProductDetailId { get; set; }
    public ProductDetail? ProductDetail { get; set; }
    public ICollection<Wishlist>? Wishlists { get; set; }
    public ICollection<Image>? Images { get; set; }
    public ICollection<Cart>? Baskets { get; set; }
    public ICollection<Tag>? Tags { get; set; }
    public List<SubCategory>? SubCategories { get; set; }
}

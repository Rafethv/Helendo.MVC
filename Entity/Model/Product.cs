using Entity.Base;
using Entity.Entity;
using Entity.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model;

public class Product : BaseEntity, IEntity
{
    public string? Title { get; set; }
    public double Price { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public int ProductDetailId { get; set; }
    public ProductDetail? ProductDetail { get; set; }

    [NotMapped]
    public IFormFile? MainFile { get; set; }

    [NotMapped]
    public List<IFormFile>? ImageFile { get; set; }

    public ICollection<Wishlist>? Wishlists { get; set; }
    public ICollection<Image>? Images { get; set; }
    public ICollection<Cart>? Baskets { get; set; }
    public ICollection<Tag>? Tags { get; set; }
    public ICollection<SubCategory>? SubCategories { get; set; }

    [NotMapped]
    public List<int>? SubCategoryIds { get; set; }
}

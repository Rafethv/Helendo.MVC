using DAL.Model;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity;

public class AppUser : IdentityUser
{

    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public int ImageId { get; set; }
    public Image? Image { get; set; }

    public ICollection<Blog>? Blogs { get; set; }
    public ICollection<Product>? Products { get; set; }

    public int CartId { get; set; }
    public Cart? Cart { get; set; }
    public int WishlistId { get; set; }
    public Wishlist? Wishlist { get; set; }
}

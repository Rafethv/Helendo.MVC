using Entity.Identity;
using Entity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


    public DbSet<Image> Images { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogDetail> BlogDetails { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
}

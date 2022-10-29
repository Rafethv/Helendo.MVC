using Entity.Entity;
using Entity.Identity;

namespace Entity.Model;

public class Image : IEntity
{
    public int Id { get; set; }
    public string? Url { get; set; }
    public bool? IsMain { get; set; }
    public AppUser? User { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Blog>? Blogs { get; set; }
}

using Entity.Model;

namespace Business.ViewModels;

public class GetBlogVM
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ICollection<Image>? Images { get; set; }
    public DateTime CreateDate { get; set; }
}

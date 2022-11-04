using Entity.Model;

namespace Business.ViewModels;

public class GetBlogDetailVM
{
    public string? Content { get; set; }
    public string? Title { get; set; }
    public string? Desciption { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public DateTime CreateDate { get; set; }

    public ICollection<Image>? Images { get; set; }
}

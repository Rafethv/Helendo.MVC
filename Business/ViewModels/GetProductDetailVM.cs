using Entity.Model;

namespace Business.ViewModels;

public class GetProductDetailVM
{
    public string? Description { get; set; }
    public double Weight { get; set; }
    public string? Title { get; set; }
    public double Price { get; set; }
    public ICollection<Image>? Images { get; set; }
    public ICollection<SubCategory>? SubCategories { get; set; }
}

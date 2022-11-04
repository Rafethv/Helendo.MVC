using Entity.Model;

namespace Business.ViewModels;

public class GetProductVM
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public double Price { get; set; }
    public ICollection<Image>? Images { get; set; }
}

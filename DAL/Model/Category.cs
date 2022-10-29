using DAL.Base;
using DAL.Entity;

namespace DAL.Model;

public class Category : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public ICollection<SubCategory>? SubCategories { get; set; }
}

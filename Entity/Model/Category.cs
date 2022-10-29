using Entity.Base;
using Entity.Entity;

namespace Entity.Model;

public class Category : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public ICollection<SubCategory>? SubCategories { get; set; }
}

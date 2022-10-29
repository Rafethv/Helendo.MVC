using DAL.Base;
using DAL.Entity;

namespace DAL.Model;

public class BlogDetail : BaseEntity, IEntity
{
    public string? Content { get; set; }
    public Blog? Blog { get; set; }
}

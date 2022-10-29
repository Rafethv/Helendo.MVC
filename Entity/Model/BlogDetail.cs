using Entity.Base;
using Entity.Entity;

namespace Entity.Model;

public class BlogDetail : BaseEntity, IEntity
{
    public string? Content { get; set; }
    public Blog? Blog { get; set; }
}

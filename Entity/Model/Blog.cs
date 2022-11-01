using Entity.Base;
using Entity.Entity;
using Entity.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model;

public class Blog : BaseEntity, IEntity
{
    public string? Title { get; set; }
    public string? Desciption { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public int BlogDetailId { get; set; }
    public BlogDetail? BlogDetail { get; set; }

    [NotMapped]
    public IFormFile? MainFile { get; set; }

    [NotMapped]
    public List<IFormFile>? ImageFile { get; set; }

    public ICollection<Image>? Images { get; set; }
}

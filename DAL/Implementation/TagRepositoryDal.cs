using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class TagRepositoryDal : EFRepositoryBase<Tag, AppDbContext>, ITagDal
{
    public TagRepositoryDal(AppDbContext context) : base(context) { }
}

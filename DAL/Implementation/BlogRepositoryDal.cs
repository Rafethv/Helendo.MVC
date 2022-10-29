using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class BlogRepositoryDal : EFRepositoryBase<Blog, AppDbContext>, IBlogDal
{
    public BlogRepositoryDal(AppDbContext context) : base(context) {}
}

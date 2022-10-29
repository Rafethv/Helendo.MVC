using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class BlogDetailRepositoryDal : EFRepositoryBase<BlogDetail, AppDbContext>, IBlogDetailDal
{
    public BlogDetailRepositoryDal(AppDbContext context) : base(context){}
}

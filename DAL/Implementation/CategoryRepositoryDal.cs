using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class CategoryRepositoryDal : EFRepositoryBase<Category, AppDbContext>, ICategoryDal
{
    public CategoryRepositoryDal(AppDbContext context) : base(context) {}
}

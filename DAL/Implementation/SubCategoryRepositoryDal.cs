using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class SubCategoryRepositoryDal : EFRepositoryBase<SubCategory, AppDbContext>, ISubCategoryDal
{
    public SubCategoryRepositoryDal(AppDbContext context) : base(context) { }
}

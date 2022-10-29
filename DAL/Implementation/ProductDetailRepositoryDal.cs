using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class ProductDetailRepositoryDal : EFRepositoryBase<ProductDetail, AppDbContext>, IProductDetailDal
{
    public ProductDetailRepositoryDal(AppDbContext context) : base(context) {}
}

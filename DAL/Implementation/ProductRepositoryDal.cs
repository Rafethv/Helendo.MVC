using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class ProductRepositoryDal : EFRepositoryBase<Product, AppDbContext>, IProductDal
{
    public ProductRepositoryDal(AppDbContext context) : base(context) { }
}

using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class ProductDetailRepository : IProductDetailService
{
    private readonly IProductDetailDal _productDetailDal;

    public ProductDetailRepository(IProductDetailDal productDetailDal)
    {
        _productDetailDal = productDetailDal;
    }

    public Task CreateAsync(ProductDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDetail> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDetail>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, ProductDetail entity)
    {
        throw new NotImplementedException();
    }
}

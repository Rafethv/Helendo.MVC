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

    public Task Create(ProductDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDetail> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDetail>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, ProductDetail entity)
    {
        throw new NotImplementedException();
    }
}

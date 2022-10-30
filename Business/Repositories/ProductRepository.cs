using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class ProductRepository : IProductService
{
    private readonly IProductDal _productDal;

    public ProductRepository(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public Task Create(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Product entity)
    {
        throw new NotImplementedException();
    }
}

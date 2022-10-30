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

    public Task CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Product entity)
    {
        throw new NotImplementedException();
    }
}

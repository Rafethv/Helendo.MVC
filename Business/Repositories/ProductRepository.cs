using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class ProductRepository : IProductService
{
    private readonly IProductDal _productDal;

    public ProductRepository(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task<Product> GetAsync(int id)
    {
        Product product = await _productDal.GetAsync(p => p.Id == id, "User.Image", "ProductDetail");
        if (product is null) throw new EntityIsNullException();
        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        List<Product> products = await _productDal.GetAllAsync(p => !p.IsDeleted, 0, int.MaxValue, "User.Image", "ProductDetail");
        if(products is null) throw new EntityIsNullException();
        return products;
    }

    public Task CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        Product product = await _productDal.GetAsync(p => p.Id == id);
        if(product is null) throw new EntityIsNullException();
        await _productDal.DeleteAsync(product);
    }
}

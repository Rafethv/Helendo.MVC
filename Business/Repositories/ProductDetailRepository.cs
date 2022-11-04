using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class ProductDetailRepository : IProductDetailService
{
    private readonly IProductDetailDal _productDetailDal;

    public ProductDetailRepository(IProductDetailDal productDetailDal)
    {
        _productDetailDal = productDetailDal;
    }

    public async Task<ProductDetail> GetAsync(int id)
    {
        ProductDetail productDetail = await _productDetailDal.GetAsync(pd => pd.Id == id, "Product");
        if (productDetail is null) throw new EntityIsNullException();
        return productDetail;
    }

    public async Task<List<ProductDetail>> GetAllAsync()
    {
        List<ProductDetail> productDetails = await _productDetailDal.GetAllAsync(pd => !pd.IsDeleted, "Product");
        if(productDetails is null) throw new EntityIsNullException();
        return productDetails;
    }

    public Task CreateAsync(ProductDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, ProductDetail entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        ProductDetail productDetail = await _productDetailDal.GetAsync(pd => pd.Id == id);
        if(productDetail is null) throw new EntityIsNullException();
        await _productDetailDal.DeleteAsync(productDetail);
    }
}

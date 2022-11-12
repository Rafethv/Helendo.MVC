using Business.Base;
using Entity.Model;

namespace Business.Services;

public interface IProductService : IBaseService<Product> {
    Task<List<Product>> GetPaginationAsync(int page, int pageSize);
    Task UpdateProductWishlistAsync(Product product);
}

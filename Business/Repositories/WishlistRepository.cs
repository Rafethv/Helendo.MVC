using Business.Services;
using Entity.Model;

namespace Business.Repositories;

public class WishlistRepository : IWishlistService
{
    private readonly IWishlistService _wishlistService;

    public WishlistRepository(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    public Task CreateAsync(Wishlist entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Wishlist> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Wishlist>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Wishlist entity)
    {
        throw new NotImplementedException();
    }
}

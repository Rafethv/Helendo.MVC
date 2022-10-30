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

    public Task Create(Wishlist entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Wishlist> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Wishlist>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Wishlist entity)
    {
        throw new NotImplementedException();
    }
}

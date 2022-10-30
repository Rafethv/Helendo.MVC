using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class WishlistRepository : IWishlistService
{
    private readonly IWishlistDal _wishlistDal;

    public WishlistRepository(IWishlistDal wishlistDal)
    {
        _wishlistDal = wishlistDal;
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

using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class WishlistRepository : IWishlistService
{
    private readonly IWishlistDal _wishlistDal;

    public WishlistRepository(IWishlistDal wishlistDal)
    {
        _wishlistDal = wishlistDal;
    }

    public async Task<Wishlist> GetAsync(int id)
    {
        Wishlist wishlist = await _wishlistDal.GetAsync(n => n.Id == id, "Products", "User");
        if (wishlist is null) throw new EntityIsNullException();
        return wishlist;
    }

    public Task<List<Wishlist>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Wishlist entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, Wishlist entity)
    {
        Wishlist wishlist = await _wishlistDal.GetAsync(n => n.Id == id, "Products");
        wishlist.Products = entity.Products;
        await _wishlistDal.UpdateAsync(wishlist);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}

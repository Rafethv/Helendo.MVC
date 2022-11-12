using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class CartRepository : ICartService
{
    private readonly ICartDal _cartDal;

    public CartRepository(ICartDal cartDal)
    {
        _cartDal = cartDal;
    }

    public async Task<Cart> GetAsync(int id)
    {
        Cart cart = await _cartDal.GetAsync(n => n.Id == id, "Products.Images", "User");
        if (cart is null) throw new EntityIsNullException();
        return cart;
    }

    public Task<List<Cart>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Cart entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, Cart entity)
    {
        Cart cart = await _cartDal.GetAsync(n => n.Id == id, "Products");
        cart.Products = entity.Products;
        cart.TotalPrice = entity.TotalPrice;
        await _cartDal.UpdateAsync(cart);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}

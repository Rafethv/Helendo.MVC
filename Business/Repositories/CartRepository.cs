using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class CartRepository : ICartService
{
    private readonly ICartDal _cartDal;

    public CartRepository(ICartDal cartDal)
    {
        _cartDal = cartDal;
    }

    public Task CreateAsync(Cart entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cart>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Cart entity)
    {
        throw new NotImplementedException();
    }
}

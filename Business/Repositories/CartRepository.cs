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

    public Task Create(Cart entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cart>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Cart entity)
    {
        throw new NotImplementedException();
    }
}

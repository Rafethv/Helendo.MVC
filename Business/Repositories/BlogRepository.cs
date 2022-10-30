using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class BlogRepository : IBlogService
{
    private readonly IBlogDal _blogDal;

    public BlogRepository(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public Task CreateAsync(Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Blog> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Blog>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Blog entity)
    {
        throw new NotImplementedException();
    }
}

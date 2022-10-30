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

    public Task Create(Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Blog> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Blog>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Blog entity)
    {
        throw new NotImplementedException();
    }
}

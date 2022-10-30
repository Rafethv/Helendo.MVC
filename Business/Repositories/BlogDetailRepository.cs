using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class BlogDetailRepository : IBlogDetailService
{
    private readonly IBlogDetailDal _blogDetailDal;

    public BlogDetailRepository(IBlogDetailDal blogDetailDal)
    {
        _blogDetailDal = blogDetailDal;
    }

    public Task CreateAsync(BlogDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogDetail> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BlogDetail>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, BlogDetail entity)
    {
        throw new NotImplementedException();
    }
}

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

    public Task Create(BlogDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogDetail> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BlogDetail>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, BlogDetail entity)
    {
        throw new NotImplementedException();
    }
}

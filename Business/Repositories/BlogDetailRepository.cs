using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class BlogDetailRepository : IBlogDetailService
{
    private readonly IBlogDetailDal _blogDetailDal;

    public BlogDetailRepository(IBlogDetailDal blogDetailDal)
    {
        _blogDetailDal = blogDetailDal;
    }

    public async Task<BlogDetail> GetAsync(int id)
    {
        BlogDetail blogDetail = await _blogDetailDal.GetAsync(bd => bd.Id == id, "Blog");
        if (blogDetail is null) throw new EntityIsNullException();
        return blogDetail;
    }

    public async Task<List<BlogDetail>> GetAllAsync()
    {
        List<BlogDetail> blogDetails = await _blogDetailDal.GetAllAsync(bd => !bd.IsDeleted, "Blog");
        if(blogDetails is null) throw new EntityIsNullException();
        return blogDetails;
    }

    public Task CreateAsync(BlogDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, BlogDetail entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        BlogDetail blogDetail = await _blogDetailDal.GetAsync(bd => bd.Id == id);
        if( blogDetail is null) throw new EntityIsNullException();
        await _blogDetailDal.DeleteAsync(blogDetail);
    }
}

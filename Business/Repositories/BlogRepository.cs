using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class BlogRepository : IBlogService
{
    private readonly IBlogDal _blogDal;

    public BlogRepository(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public async Task<Blog> GetAsync(int id)
    {
        Blog blog = await _blogDal.GetAsync(b => b.Id == id, "User.Image", "BlogDetail", "Images");
        if (blog is null) throw new EntityIsNullException();
        return blog;
    }

    public async Task<List<Blog>> GetAllAsync()
    {
        List<Blog> blogs = await _blogDal.GetAllAsync(b => !b.IsDeleted, 0, int.MaxValue, "User.Image", "BlogDetail", "Images");
        if(blogs is null) throw new EntityIsNullException();
        return blogs;
    }

    public Task CreateAsync(Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Blog entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        Blog blog = await _blogDal.GetAsync(b => b.Id == id);
        if (blog is null) throw new EntityIsNullException();
        await _blogDal.DeleteAsync(blog);
    }
}

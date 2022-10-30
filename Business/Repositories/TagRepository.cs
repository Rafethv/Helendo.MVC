using Business.Services;
using Entity.Model;

namespace Business.Repositories;

public class TagRepository : ITagService
{
    private readonly ITagService _tagService;

    public TagRepository(ITagService tagService)
    {
        _tagService = tagService;
    }

    public Task CreateAsync(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Tag> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Tag>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Tag entity)
    {
        throw new NotImplementedException();
    }
}

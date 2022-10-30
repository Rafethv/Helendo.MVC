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

    public Task Create(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Tag> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Tag>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Tag entity)
    {
        throw new NotImplementedException();
    }
}

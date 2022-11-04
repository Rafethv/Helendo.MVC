using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class TagRepository : ITagService
{
    private readonly ITagDal _tagDal;

    public TagRepository(ITagDal tagDal)
    {
        _tagDal = tagDal;
    }

    public async Task<Tag> GetAsync(int id)
    {
        Tag tag = await _tagDal.GetAsync(t => t.Id == id, "Product");
        if (tag is null) throw new EntityIsNullException();
        return tag;
    }

    public async Task<List<Tag>> GetAllAsync()
    {
        List<Tag> tags = await _tagDal.GetAllAsync(t => !t.IsDeleted, "Product");
        if(tags is null) throw new EntityIsNullException();
        return tags;
    }

    public Task CreateAsync(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Tag entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        Tag tag = await _tagDal.GetAsync(t => t.Id == id);
        if(tag is null) throw new EntityIsNullException();
        await _tagDal.DeleteAsync(tag);
    }
}

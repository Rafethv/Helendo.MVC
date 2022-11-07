using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class CategoryRepository : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryRepository(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public async Task<Category> GetAsync(int id)
    {
        Category category = await _categoryDal.GetAsync(c => c.Id == id, "SubCategories");
        if (category is null) throw new EntityIsNullException();
        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        List<Category> categories = await _categoryDal.GetAllAsync(c => !c.IsDeleted, "SubCategories");
        if(categories is null) throw new EntityIsNullException();
        return categories;
    }

    public async Task CreateAsync(Category entity)
    {
        await _categoryDal.CreateAsync(entity);
    }

    public async Task UpdateAsync(int id, Category entity)
    {
        Category category = await _categoryDal.GetAsync(c => c.Id == id);
        category.UpdateDate = DateTime.UtcNow.AddHours(4);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        category.Name = entity.Name.Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        if (entity.SubCategories is not null)
        {
            category.SubCategories = entity.SubCategories;
        }
        await _categoryDal.UpdateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        Category category = await _categoryDal.GetAsync(c => c.Id == id);
        if(category is null) throw new EntityIsNullException();
        await _categoryDal.DeleteAsync(category);
    }
}

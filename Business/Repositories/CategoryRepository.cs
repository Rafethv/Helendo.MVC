using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class CategoryRepository : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryRepository(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public Task CreateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Category entity)
    {
        throw new NotImplementedException();
    }
}

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

    public Task Create(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Category entity)
    {
        throw new NotImplementedException();
    }
}

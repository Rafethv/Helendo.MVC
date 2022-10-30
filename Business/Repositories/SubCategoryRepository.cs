using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class SubCategoryRepository : ISubCategoryService
{
    private readonly ISubCategoryDal _subCategoryDal;

    public SubCategoryRepository(ISubCategoryDal subCategoryDal)
    {
        _subCategoryDal = subCategoryDal;
    }

    public Task CreateAsync(SubCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<SubCategory> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SubCategory>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, SubCategory entity)
    {
        throw new NotImplementedException();
    }
}

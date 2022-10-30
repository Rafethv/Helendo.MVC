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

    public Task Create(SubCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<SubCategory> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SubCategory>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, SubCategory entity)
    {
        throw new NotImplementedException();
    }
}

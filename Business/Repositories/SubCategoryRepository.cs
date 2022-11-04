using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class SubCategoryRepository : ISubCategoryService
{
    private readonly ISubCategoryDal _subCategoryDal;

    public SubCategoryRepository(ISubCategoryDal subCategoryDal)
    {
        _subCategoryDal = subCategoryDal;
    }

    public async Task<SubCategory> GetAsync(int id)
    {
        SubCategory subCategory = await _subCategoryDal.GetAsync(s => s.Id == id, "Category", "Products");
        if (subCategory is null) throw new EntityIsNullException();
        return subCategory;
    }

    public async Task<List<SubCategory>> GetAllAsync()
    {
        List<SubCategory> subCategories = await _subCategoryDal.GetAllAsync(s => !s.IsDeleted, "Category", "Products");
        if(subCategories is null) throw new EntityIsNullException();
        return subCategories;
    }

    public async Task CreateAsync(SubCategory entity)
    {
        SubCategory subCategory = new()
        {
            Name = entity.Name.Trim(),
            CreateDate = DateTime.UtcNow.AddHours(4),
            Category = entity.Category,
        };

        await _subCategoryDal.CreateAsync(subCategory);
    }

    public async Task UpdateAsync(int id, SubCategory entity)
    {
        SubCategory subCategory = await _subCategoryDal.GetAsync(sb => sb.Id == id, "Products", "Category");

        subCategory.Name = entity.Name.Trim();
        if (entity.Category is not null)
        {
            subCategory.Category = entity.Category;
        }
        if (entity.Products is not null)
        {
            subCategory.Products = entity.Products;
        }
        subCategory.UpdateDate = DateTime.UtcNow.AddHours(4);

        await _subCategoryDal.UpdateAsync(subCategory);
    }

    public async Task DeleteAsync(int id)
    {
        SubCategory subCategory = await _subCategoryDal.GetAsync(s => s.Id == id);
        if(subCategory is null) throw new EntityIsNullException();
        await _subCategoryDal.DeleteAsync(subCategory);
    }
}

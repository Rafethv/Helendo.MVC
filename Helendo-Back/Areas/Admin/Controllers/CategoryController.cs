using Business.Services;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Areas.Admin.Controllers;

[Area("admin"), Authorize(Roles = "Admin,SuperAdmin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ISubCategoryService _subCategoryService;

    public CategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
    {
        _categoryService = categoryService;
        _subCategoryService = subCategoryService;
    }

    public async Task<IActionResult> Index()
    {
        List<Category> categories;

        try
        {
            categories = await _categoryService.GetAllAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return View(model: categories);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Category category;
        try
        {
            category = await _categoryService.GetAsync(id);
        }
        catch (Exception)
        {
            throw;
        }

        return View(model: category);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category entity)
    {
        if (!ModelState.IsValid)
        {
            return View(entity);
        }

        await _categoryService.CreateAsync(entity);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        Category category = await _categoryService.GetAsync(id);

        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        await _categoryService.UpdateAsync(id, category);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult AddSubCategory()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddSubCategory(int id, SubCategory entity)
    {
        if (!ModelState.IsValid)
        {
            return View(entity);
        }

        var category = await _categoryService.GetAsync(id);

        if(category.SubCategories is not null)
        {
            foreach (var subCategory in category.SubCategories)
            {
                if (subCategory.Name == entity.Name)
                {
                    return View();
                };
            }
        }

        entity.Category = category;

        await _subCategoryService.CreateAsync(entity);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateSubCategory(int id)
    {
        var data = await _subCategoryService.GetAsync(id);

        return View(model: data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateSubCategory(int id, SubCategory subCategory)
    {
        if (!ModelState.IsValid)
        {
            return View(subCategory);
        }

        await _subCategoryService.UpdateAsync(id, subCategory);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteSubCategory(int id)
    {
        await _subCategoryService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}

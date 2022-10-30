using Business.Services;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Areas.Admin.Controllers;

[Area("admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
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

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        Category category = await _categoryService.GetAsync(id);

        return View(category);
    }
}

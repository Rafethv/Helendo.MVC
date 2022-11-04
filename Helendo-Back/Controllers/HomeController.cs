using Business.Services;
using Business.ViewModels;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    private readonly IBlogService _blogService;

    public HomeController(IProductService productService, IBlogService blogService)
    {
        _productService = productService;
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        List<GetProductVM> getProductVms = new();
        foreach (Product product in await _productService.GetAllAsync())
        {
            GetProductVM getProductVm = new()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Images = product.Images,
            };
            getProductVms.Add(getProductVm);
        }

        List<GetBlogVM> getBlogVMs = new();
        foreach (Blog blog in await _blogService.GetAllAsync())
        {
            GetBlogVM getBlogVm = new()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Desciption,
                CreateDate = blog.CreateDate,
                Images = blog.Images,
            };
            getBlogVMs.Add(getBlogVm);
        }

        HomeVM homeVm = new()
        {
            Products = getProductVms,
            Blogs = getBlogVMs
        };


        return View(model: homeVm);
    }
}

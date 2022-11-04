using Business.Services;
using Business.ViewModels;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        List<GetProductVM> getProductVms = new();
        foreach (var product in await _productService.GetAllAsync())
        {
            GetProductVM getProductVm = new()
            {
                Id = product.Id,
                Title = product.Title,
                Images = product.Images,
                Price = product.Price,
            };
            getProductVms.Add(getProductVm);
        }

        ProductVM productVm = new()
        {
            Products = getProductVms,
        };

        return View(model: productVm);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Product product = await _productService.GetAsync(id);

        GetProductDetailVM getProductDetailVm = new()
        {
            Weight = product.ProductDetail.Weight,
            Description = product.ProductDetail?.Description,
            Images = product.Images,
            Price = product.Price,
            SubCategories = product.SubCategories,
            Title = product.Title,
        };

        return View(model: getProductDetailVm);
    }
}

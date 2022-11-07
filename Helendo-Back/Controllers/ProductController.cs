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

    public async Task<IActionResult> Index(int page = 1)
    {
        List<GetProductVM> getProductVms = new();
        foreach (var product in await _productService.GetPaginationAsync(page, 6))
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

    public async Task<IActionResult> Pagination(int page)
    {
        List<GetProductVM> getProductVms = new();
        foreach (var product in await _productService.GetPaginationAsync(page, 6))
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

        return PartialView("_ProductPartial", model: productVm);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Product product = await _productService.GetAsync(id);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        GetProductDetailVM getProductDetailVm = new()
        {
            Weight = product.ProductDetail.Weight,
            Description = product.ProductDetail?.Description,
            Images = product.Images,
            Price = product.Price,
            SubCategories = product.SubCategories,
            Title = product.Title,
            Color = product.ProductDetail.Color
        };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return View(model: getProductDetailVm);
    }
}

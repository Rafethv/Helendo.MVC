using Business.Services;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products;

            try
            {
                products = await _productService.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model: products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Product product;

            try
            {
                product = await _productService.GetAsync(id);
            }
            catch (Exception)
            {
                throw;
            }

            return View(model: product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _productService.GetAsync(id);

            return View(model: product);
        }
    }
}

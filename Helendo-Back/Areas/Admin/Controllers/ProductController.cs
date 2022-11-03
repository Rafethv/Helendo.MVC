using Business.Services;
using Entity.Identity;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ISubCategoryService _subCategoryService;

        public ProductController(IProductService productService, IWebHostEnvironment env, UserManager<AppUser> userManager, ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _env = env;
            _userManager = userManager;
            _subCategoryService = subCategoryService;
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
        public async Task<IActionResult> Create()
        {
            ViewData["SubCategories"] = await _subCategoryService.GetAllAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product entity)
        {
            if (entity.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(entity);
            }

            AppUser applicationUser = await _userManager.GetUserAsync(User);

            entity.User = applicationUser;

            try
            {
                await _productService.CreateAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _productService.GetAsync(id);
            ViewData["SubCategories"] = await _subCategoryService.GetAllAsync();

            return View(model: product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Product entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            try
            {
                await _productService.UpdateAsync(id, entity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

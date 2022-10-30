using Business.Services;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs;
            try
            {
                blogs = await _blogService.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return View(model: blogs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Blog blog;

            try
            {
                blog = await _blogService.GetAsync(id);
            }
            catch (Exception)
            {

                throw;
            }

            return View(model: blog);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _blogService.GetAsync(id);

            return View(model: blog);
        }
    }
}

using Business.Services;
using Entity.Identity;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Admin,SuperAdmin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(IBlogService blogService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> Create(Blog entity)
        {
            if (entity.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(entity);
            }

            AppUser applicationUser = await _userManager.GetUserAsync(User);

            entity.User = applicationUser;

            await _blogService.CreateAsync(entity);

            return RedirectToAction(nameof(Index));
        }

            [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _blogService.GetAsync(id);

            return View(model: blog);
        }
    }
}

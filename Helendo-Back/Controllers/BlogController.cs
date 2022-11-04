using Business.Services;
using Business.ViewModels;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class BlogController : Controller
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        List<GetBlogVM> getBlogVms = new();
        foreach (var blog in await _blogService.GetAllAsync())
        {
            GetBlogVM getBlogVm = new()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Desciption,
                Images = blog.Images,
                CreateDate = blog.CreateDate,
            };
            getBlogVms.Add(getBlogVm);
        }

        BlogVM blogVm = new()
        {
            Blogs = getBlogVms
        };

        return View(model: blogVm);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Blog blog = await _blogService.GetAsync(id);

        GetBlogDetailVM getBlogDetailVm = new()
        {
            Title = blog.Title,
            Content = blog.BlogDetail.Content,
            CreateDate = blog.CreateDate,
            Desciption = blog.Desciption,
            Firstname = blog.User.Firstname,
            Lastname = blog.User.Lastname,
            Images = blog.Images,
        };

        return View(model: getBlogDetailVm);
    }
}

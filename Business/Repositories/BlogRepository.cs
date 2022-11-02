using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;
using Helendo_Back.Helpers.Extensions;
using Microsoft.AspNetCore.Hosting;

namespace Business.Repositories;

public class BlogRepository : IBlogService
{
    private readonly IBlogDal _blogDal;
    private readonly IImageService _imageService;
    private readonly IWebHostEnvironment _env;

    public BlogRepository(IBlogDal blogDal, IWebHostEnvironment env, IImageService imageService)
    {
        _blogDal = blogDal;
        _env = env;
        _imageService = imageService;
    }

    public async Task<Blog> GetAsync(int id)
    {
        Blog blog = await _blogDal.GetAsync(b => b.Id == id, "User.Image", "BlogDetail", "Images");
        if (blog is null) throw new EntityIsNullException();
        return blog;
    }

    public async Task<List<Blog>> GetAllAsync()
    {
        List<Blog> blogs = await _blogDal.GetAllAsync(b => !b.IsDeleted, 0, int.MaxValue, "User.Image", "BlogDetail", "Images");
        if (blogs is null) throw new EntityIsNullException();
        return blogs;
    }

    public async Task CreateAsync(Blog entity)
    {
        List<Image> images = new();

        foreach (var imageFile in entity.ImageFile)
        {
            string fileName = await imageFile.CreateFile(_env);

            Image image = new();
            image.Url = fileName;
            image.IsMain = false;
            images.Add(image);
        }

        Image mainImage = new();
        string mainFileName = await entity.MainFile.CreateFile(_env);
        mainImage.Url = mainFileName;
        mainImage.IsMain = true;
        images.Add(mainImage);

        entity.Images = images;

        BlogDetail blogDetail = new()
        {
            Content = entity.BlogDetail.Content,
            CreateDate = DateTime.UtcNow.AddHours(4),
        };

        entity.BlogDetail = blogDetail;

        await _blogDal.CreateAsync(entity);
    }

    public Task UpdateAsync(int id, Blog entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        Blog blog = await _blogDal.GetAsync(b => b.Id == id);
        if (blog is null) throw new EntityIsNullException();
        await _blogDal.DeleteAsync(blog);
    }
}

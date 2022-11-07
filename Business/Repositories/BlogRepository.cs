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
    private readonly IBlogDetailDal _blogDetailDal;
    private readonly IImageDal _imageDal;
    private readonly IWebHostEnvironment _env;

    public BlogRepository(IBlogDal blogDal, IWebHostEnvironment env, IImageDal imageDal, IBlogDetailDal blogDetailDal)
    {
        _blogDal = blogDal;
        _env = env;
        _imageDal = imageDal;
        _blogDetailDal = blogDetailDal;
    }

    public async Task<Blog> GetAsync(int id)
    {
        Blog blog = await _blogDal.GetAsync(b => b.Id == id, "User.Image", "BlogDetail", "Images");
        if (blog is null) throw new EntityIsNullException();
        return blog;
    }

    public async Task<List<Blog>> GetAllAsync()
    {
        List<Blog> blogs = await _blogDal.GetAllAsync(b => !b.IsDeleted, "User.Image", "BlogDetail", "Images");
        if (blogs is null) throw new EntityIsNullException();
        return blogs;
    }

    public async Task<List<Blog>> GetPaginationAsync(int page, int pageSize)
    {
        List<Blog> blogs = await _blogDal.PaginationAsync(b => b.CreateDate ,b => !b.IsDeleted, page, pageSize, "User.Image", "BlogDetail", "Images");
        if (blogs is null) throw new EntityIsNullException();
        return blogs;
    }

    public async Task CreateAsync(Blog entity)
    {
        List<Image> images = new();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        foreach (var imageFile in entity.ImageFile)
        {
            string fileName = await imageFile.CreateFile(_env);

            Image image = new();
            image.Url = fileName;
            image.IsMain = false;
            images.Add(image);
            await _imageDal.CreateAsync(image);
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        Image mainImage = new();
#pragma warning disable CS8604 // Possible null reference argument.
        string mainFileName = await entity.MainFile.CreateFile(_env);
#pragma warning restore CS8604 // Possible null reference argument.
        mainImage.Url = mainFileName;
        mainImage.IsMain = true;
        images.Add(mainImage);
        await _imageDal.CreateAsync(mainImage);

        entity.Images = images;
        entity.CreateDate = DateTime.UtcNow.AddHours(4);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        BlogDetail blogDetail = new()
        {
            Content = entity.BlogDetail.Content,
            CreateDate = DateTime.UtcNow.AddHours(4),
        };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        await _blogDetailDal.CreateAsync(blogDetail);

        entity.BlogDetailId = blogDetail.Id;

        await _blogDal.CreateAsync(entity);
    }

    public async Task UpdateAsync(int id, Blog entity)
    {
        List<Image> currentImages = new();
        Blog blog = await _blogDal.GetAsync(b => b.Id == id, "User.Image", "BlogDetail", "Images");

        if (entity.ImageFile is not null)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            for (int i = 0; i < blog.Images.Where(n => n.IsMain == false).ToList().Count; i++)
            {
                currentImages.Add(blog.Images.Where(n => n.IsMain == false).ToList()[i]);
            }
#pragma warning restore CS8604 // Possible null reference argument.

            foreach (var imageFile in entity.ImageFile)
            {
                string fileName = await imageFile.CreateFile(_env);

                Image image = new();
                image.Url = fileName;
                image.IsMain = false;
                currentImages.Add(image);
                await _imageDal.CreateAsync(image);
            }
        }
        else
        {
#pragma warning disable CS8604 // Possible null reference argument.
            for (int i = 0; i < blog.Images.Where(n => n.IsMain == false).ToList().Count; i++)
            {
                currentImages.Add(blog.Images.Where(n => n.IsMain == false).ToList()[i]);
            }
#pragma warning restore CS8604 // Possible null reference argument.
        }

        if (entity.MainFile is not null)
        {
            string fileName = await entity.MainFile.CreateFile(_env);

            Image image = new();
            image.Url = fileName;
            image.IsMain = true;
            currentImages.Add(image);
            await _imageDal.CreateAsync(image);

#pragma warning disable CS8604 // Possible null reference argument.
            await _imageDal.DeleteAsync(blog.Images.Where(n => n.IsMain == true).FirstOrDefault());
        }
        else
        {
            currentImages.Add(blog.Images.Where(n => n.IsMain == true).FirstOrDefault());
        }
#pragma warning restore CS8604 // Possible null reference argument.

        blog.Images = currentImages;
        blog.Title = entity.Title;
        blog.Desciption = entity.Desciption;
        blog.UpdateDate = DateTime.UtcNow.AddHours(4);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        blog.BlogDetail.Content = entity.BlogDetail.Content;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        await _blogDal.UpdateAsync(blog);
    }

    public async Task DeleteAsync(int id)
    {
        Blog blog = await _blogDal.GetAsync(b => b.Id == id);
        if (blog is null) throw new EntityIsNullException();
        await _blogDal.DeleteAsync(blog);
    }

}

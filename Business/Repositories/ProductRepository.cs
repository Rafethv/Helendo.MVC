using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;
using Helendo_Back.Helpers.Extensions;
using Microsoft.AspNetCore.Hosting;

namespace Business.Repositories;

public class ProductRepository : IProductService
{
    private readonly IProductDal _productDal;
    private readonly IWebHostEnvironment _env;
    private readonly IImageDal _imageDal;

    public ProductRepository(IProductDal productDal, IWebHostEnvironment env, IImageDal imageDal)
    {
        _productDal = productDal;
        _env = env;
        _imageDal = imageDal;
    }

    public async Task<Product> GetAsync(int id)
    {
        Product product = await _productDal.GetAsync(p => p.Id == id, "User.Image", "ProductDetail");
        if (product is null) throw new EntityIsNullException();
        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        List<Product> products = await _productDal.GetAllAsync(p => !p.IsDeleted, 0, int.MaxValue, "User.Image", "ProductDetail");
        if(products is null) throw new EntityIsNullException();
        return products;
    }

    public async Task CreateAsync(Product entity)
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

        ProductDetail serviceDetail = new()
        {
            Description = entity.ProductDetail.Description,
            Weight = entity.ProductDetail.Weight,
        };

        entity.ProductDetail = serviceDetail;
        entity.ProductDetailId = serviceDetail.Id;

        await _productDal.CreateAsync(entity);
    }

    public async Task UpdateAsync(int id, Product entity)
    {
        List<Image> currentImages = new();
        Product product = await _productDal.GetAsync(p => p.Id == id);

        if (entity.ImageFile is not null)
        {
            for (int i = 0; i < product.Images.Where(n => n.IsMain == false).ToList().Count; i++)
            {
                currentImages.Add(product.Images.Where(n => n.IsMain == false).ToList()[i]);
            }

            foreach (var imageFile in entity.ImageFile)
            {
                string fileName = await imageFile.CreateFile(_env);

                Image image = new();
                image.Url = fileName;
                image.IsMain = false;
                currentImages.Add(image);
            }

            var images = product.Images;
            currentImages.AddRange(images);
        }
        else
        {
            for (int i = 0; i < product.Images.Where(n => n.IsMain == false).ToList().Count; i++)
            {
                currentImages.Add(product.Images.Where(n => n.IsMain == false).ToList()[i]);
            }
        }

        if (entity.MainFile is not null)
        {
            string fileName = await entity.MainFile.CreateFile(_env);

            Image image = new();
            image.Url = fileName;
            image.IsMain = true;
            currentImages.Add(image);

            await _imageDal.DeleteAsync(product.Images.Where(n => n.IsMain == true).FirstOrDefault());
        }
        else
        {
            currentImages.Add(product.Images.Where(n => n.IsMain == true).FirstOrDefault());
        }

        entity.Images = currentImages;

        await _productDal.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        Product product = await _productDal.GetAsync(p => p.Id == id);
        if(product is null) throw new EntityIsNullException();
        await _productDal.DeleteAsync(product);
    }
}

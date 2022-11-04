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
    private readonly ISubCategoryDal _subCategoryDal;
    private readonly IProductDetailDal _productDetailDal;
    private readonly IWebHostEnvironment _env;
    private readonly IImageDal _imageDal;

    public ProductRepository(IProductDal productDal, IWebHostEnvironment env, IImageDal imageDal, ISubCategoryDal subCategoryDal, IProductDetailDal productDetailDal)
    {
        _productDal = productDal;
        _env = env;
        _imageDal = imageDal;
        _subCategoryDal = subCategoryDal;
        _productDetailDal = productDetailDal;
    }

    public async Task<Product> GetAsync(int id)
    {
        Product product = await _productDal.GetAsync(p => p.Id == id, "User.Image", "ProductDetail", "Images", "SubCategories");
        if (product is null) throw new EntityIsNullException();
        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        List<Product> products = await _productDal.GetAllAsync(p => !p.IsDeleted, "User.Image", "ProductDetail", "Images", "SubCategories");
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
            await _imageDal.CreateAsync(image);
        }

        Image mainImage = new();
        string mainFileName = await entity.MainFile.CreateFile(_env);
        mainImage.Url = mainFileName;
        mainImage.IsMain = true;
        images.Add(mainImage);
        await _imageDal.CreateAsync(mainImage);

        entity.Images = images;

        ProductDetail productDetail = new()
        {
            Description = entity.ProductDetail.Description,
            Weight = entity.ProductDetail.Weight,
        };

        await _productDetailDal.CreateAsync(productDetail);

        entity.ProductDetailId = productDetail.Id;

        ICollection<SubCategory> subCategories = await _subCategoryDal.GetAllAsync(n => entity.SubCategoryIds.Contains(n.Id), "Products");

        entity.SubCategories = subCategories;

        await _productDal.CreateAsync(entity);

        foreach (var subCategory in subCategories)
        {
            subCategory.Products.Add(entity);
            await _subCategoryDal.UpdateAsync(subCategory);
        }
    }

    public async Task UpdateAsync(int id, Product entity)
    {
        List<Image> currentImages = new();
        Product product = await _productDal.GetAsync(p => p.Id == id, "User.Image", "ProductDetail", "Images", "SubCategories");

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
                await _imageDal.CreateAsync(image);
            }
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
            await _imageDal.CreateAsync(image);

            await _imageDal.DeleteAsync(product.Images.Where(n => n.IsMain == true).FirstOrDefault());
        }
        else
        {
            currentImages.Add(product.Images.Where(n => n.IsMain == true).FirstOrDefault());
        }

        ICollection<SubCategory> AllSubCategories = await _subCategoryDal.GetAllAsync(n => !n.IsDeleted, "Products");

        ICollection<SubCategory> subCategories = await _subCategoryDal.GetAllAsync(n => entity.SubCategoryIds.Contains(n.Id), "Products");

        product.SubCategories = subCategories;

        foreach (var subCategory in AllSubCategories)
        {
            if (!subCategory.Products.Select(p => p.Id).Contains(product.Id) && entity.SubCategoryIds.Contains(subCategory.Id))
            {
                subCategory.Products.Add(product);
                await _subCategoryDal.UpdateAsync(subCategory);
            }
            else if (subCategory.Products.Select(p => p.Id).Contains(product.Id) && !entity.SubCategoryIds.Contains(subCategory.Id))
            {
                subCategory.Products.Remove(product);
                await _subCategoryDal.UpdateAsync(subCategory);
            }
        }

        product.Images = currentImages;
        product.Title = entity.Title;
        product.Price = entity.Price;
        product.ProductDetail.Weight = entity.ProductDetail.Weight;
        product.ProductDetail.Description = entity.ProductDetail.Description;

        

        await _productDal.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        Product product = await _productDal.GetAsync(p => p.Id == id, "ProductDetail");
        if(product is null) throw new EntityIsNullException();
        await _productDal.DeleteAsync(product);
    }
}

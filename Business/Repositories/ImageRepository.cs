using Business.Services;
using DAL.Abstracts;
using Entity.Model;
using Exceptions.Entity;

namespace Business.Repositories;

public class ImageRepository : IImageService
{
    private readonly IImageDal _imageDal;

    public ImageRepository(IImageDal imageDal)
    {
        _imageDal = imageDal;   
    }

    public async Task<Image> GetAsync(int id)
    {
        Image image = await _imageDal.GetAsync(i => i.Id == id);
        if (image is null) throw new EntityIsNullException();
        return image;
    }

    public async Task<List<Image>> GetAllAsync()
    {
        List<Image> images = await _imageDal.GetAllAsync();
        if(images is null) throw new EntityIsNullException();
        return images;
    }

    public Task CreateAsync(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Image entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        Image image = await _imageDal.GetAsync(i => i.Id == id);
        if (image is null) throw new EntityIsNullException();
        await _imageDal.DeleteAsync(image);
    }
}

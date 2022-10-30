using Business.Services;
using DAL.Abstracts;
using Entity.Model;

namespace Business.Repositories;

public class ImageRepository : IImageService
{
    private readonly IImageDal _imageDal;

    public ImageRepository(IImageDal imageDal)
    {
        _imageDal = imageDal;   
    }

    public Task CreateAsync(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Image> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Image>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Image entity)
    {
        throw new NotImplementedException();
    }
}

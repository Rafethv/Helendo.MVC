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

    public Task Create(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Image> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Image>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Image entity)
    {
        throw new NotImplementedException();
    }
}

using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class ImageRepositoryDal : EFRepositoryBase<Image, AppDbContext>, IImageDal
{
    public ImageRepositoryDal(AppDbContext context) : base(context) { }
}

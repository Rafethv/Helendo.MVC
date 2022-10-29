using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;

namespace DAL.Implementation;

public class WishlistRepositoryDal : EFRepositoryBase<Wishlist, AppDbContext>, IWishlistDal
{
    public WishlistRepositoryDal(AppDbContext context) : base(context) { }
}

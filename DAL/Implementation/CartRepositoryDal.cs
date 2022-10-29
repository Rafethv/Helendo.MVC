using Core.EFRepository;
using DAL.Abstracts;
using DAL.Data;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation;

public class CartRepositoryDal : EFRepositoryBase<Cart, AppDbContext>, ICartDal
{
    public CartRepositoryDal(AppDbContext context) : base(context) {}
}

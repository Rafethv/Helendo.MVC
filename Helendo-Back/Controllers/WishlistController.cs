using Business.Services;
using Entity.Identity;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class WishlistController : Controller
{
    private readonly IWishlistService _wishlistService;
    private readonly IProductService _productService;
    private readonly UserManager<AppUser> _userManager;

    public WishlistController(IWishlistService wishlistService, UserManager<AppUser> userManager, IProductService productService)
    {
        _wishlistService = wishlistService;
        _userManager = userManager;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        if(User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            var userWishlist = await _wishlistService.GetAsync(user.WishlistId);

            return View(model: userWishlist);
        }else
        {
            return View(model: null);
        }
    }


    public async Task<IActionResult> AddToWishlist(int id)
    {
        Wishlist wishlist = new();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            Wishlist wishlistDb = await _wishlistService.GetAsync(user.WishlistId);
            Product product = await _productService.GetAsync(id);

            product.Wishlists.Add(wishlistDb);
            await _productService.UpdateProductWishlistAsync(product);

            wishlistDb.Products.Add(product);
            await _wishlistService.UpdateAsync(wishlistDb.Id, wishlistDb);
            wishlist = wishlistDb;
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return PartialView("_WishlistPartial", model: wishlist);
    }


    public async Task<IActionResult> DeleteFromWishlist(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        Wishlist wishlist = await _wishlistService.GetAsync(user.WishlistId);

        Product productDb = await _productService.GetAsync(id);

        List<Wishlist> wishlistList = new();

        foreach (var productWishlist in productDb.Wishlists)
        {
            if(wishlist.Id != productWishlist.Id)
            {
                wishlistList.Add(productWishlist);
            }
        }
        
        productDb.Wishlists = wishlistList;

        await _productService.UpdateProductWishlistAsync(productDb);

        List<Product> productList = new();

        foreach (var product in wishlist.Products)
        {
            if (product.Id != productDb.Id)
            {
                productList.Add(product);
            };
        };

        wishlist.Products = productList;

        await _wishlistService.UpdateAsync(wishlist.Id, wishlist);

        return PartialView("_WishlistPartial", model: wishlist);
    }
}

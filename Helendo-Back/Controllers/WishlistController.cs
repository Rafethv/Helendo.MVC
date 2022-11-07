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
        var user = await _userManager.GetUserAsync(User);
        var userWishlist = await _wishlistService.GetAsync(user.WishlistId);

        return View(model: userWishlist);
    }


    public async Task<IActionResult> AddToWishlist(int id)
    {
        List<Product> products = new();
        Wishlist wishlist = new();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            wishlist = await _wishlistService.GetAsync(user.CartId);

#pragma warning disable CS8604 // Possible null reference argument.
            products.AddRange(wishlist.Products);
#pragma warning restore CS8604 // Possible null reference argument.
            var product = await _productService.GetAsync(id);
            product.Wishlists.Add(wishlist);

            wishlist.Products = products;
            await _wishlistService.UpdateAsync(wishlist.Id, wishlist);
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return PartialView("_WishlistPartial", model: wishlist);
    }


    public async Task<IActionResult> DeleteFromWishlist(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        var wishlist = await _wishlistService.GetAsync(user.WishlistId);

        List<Product> products = new();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        foreach (var product in wishlist.Products)
        {
            if (product.Id != id)
            {
                products.Add(product);
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        wishlist.Products = products;

        await _wishlistService.UpdateAsync(wishlist.Id, wishlist);

        return PartialView("_WishlistPartial", model: wishlist);
    }
}

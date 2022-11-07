using Business.Services;
using Entity.Identity;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class CartController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICartService _cartService;
    private readonly IProductService _productService;

    public CartController(UserManager<AppUser> userManager, ICartService cartService, IProductService productService)
    {
        _userManager = userManager;
        _cartService = cartService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var userCart = await _cartService.GetAsync(user.WishlistId);

        return View(model: userCart);
    }

    public async Task<IActionResult> AddToBasket(int id)
    {
        List<Product> products = new();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _cartService.GetAsync(user.CartId);

#pragma warning disable CS8604 // Possible null reference argument.
            products.AddRange(cart.Products);
#pragma warning restore CS8604 // Possible null reference argument.
            products.Add(await _productService.GetAsync(id));
            cart.Products = products;
            await _cartService.UpdateAsync(cart.Id, cart);
        }
        else
        {
            var product = await _cartService.GetAsync(id);
            Response.Cookies.Append("BasketProducts", product.Id.ToString());
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return ViewComponent("Basket");
    }

    public async Task<IActionResult> DeleteFromBasket(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        var cart = await _cartService.GetAsync(user.CartId);

        List<Product> products = new();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        foreach (var product in cart.Products)
        {
            if (product.Id != id)
            {
                products.Add(product);
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        cart.Products = products;

        await _cartService.UpdateAsync(cart.Id, cart);

        return ViewComponent("Basket");
    }
}

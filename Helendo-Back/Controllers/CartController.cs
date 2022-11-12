using Business.Services;
using Business.ViewModels;
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
        var userCart = await _cartService.GetAsync(user.CartId);

        return View(model: userCart);
    }

    public async Task<IActionResult> AddToBasket(int id)
    {
        Cart cart = new();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            Cart cartDb = await _cartService.GetAsync(user.CartId);
            Product product = await _productService.GetAsync(id);

            product.Baskets.Add(cartDb);
            await _productService.UpdateProductWishlistAsync(product);

            cartDb.Products.Add(product);
            cartDb.TotalPrice += (int) product.Price;
            await _cartService.UpdateAsync(cartDb.Id, cartDb);
            cart = cartDb;
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return PartialView("_CartPartial", model: cart);
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

    public async Task<IActionResult> CartTotalPrice()
    {
        var user = await _userManager.GetUserAsync(User);
        var cart = await _cartService.GetAsync(user.CartId);

        return PartialView("_CartTotalPartial", model: cart);
    }
}

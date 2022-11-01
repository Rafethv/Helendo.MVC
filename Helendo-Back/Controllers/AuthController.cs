using Business.Services;
using Business.ViewModels;
using Entity.Identity;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using static Utilities.Helpers.Enums;

namespace Helendo_Back.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IWishlistService _wishlistService;

        public AuthController(UserManager<AppUser> userManager,
               RoleManager<IdentityRole> roleManager,
               SignInManager<AppUser> signInManager,
               ICartService cartService,
               IProductService productService,
               IWishlistService wishlistService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _cartService = cartService;
            _productService = productService;
            _wishlistService = wishlistService;
        }

        [HttpGet(nameof(Login))]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginVM LoginVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json("Ok");
            }

            if (!ModelState.IsValid)
            {
                return View(LoginVM);
            }

            AppUser appUser = await _userManager.FindByNameAsync(LoginVM.Username);

            if (appUser is null)
            {
                ModelState.AddModelError("", "Username not found!");
                return View(LoginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, LoginVM.Password, LoginVM.RememberMe, true);

            if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Please confirm your account!");
                return View(LoginVM);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your profile has been locked!\nPlease try later!");
                return View(LoginVM);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username not found!");
                return View(LoginVM);
            }

            if (await _userManager.IsInRoleAsync(appUser, Roles.Admin.ToString()))
            {
                return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Admin" });
            }


            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpGet(nameof(Register))]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterVM RegisterVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json("Ok");
            }

            if (!ModelState.IsValid)
            {
                return View(RegisterVM);
            }

            AppUser appUser = new();

            Cart basket = new()
            {
                TotalPrice = 0
            };

            Wishlist wishlist = new();

            appUser.Firstname = RegisterVM.Firstname;
            appUser.Lastname = RegisterVM.Lastname;
            appUser.Email = RegisterVM.Email;
            appUser.UserName = RegisterVM.Username;
            appUser.Cart = basket;
            appUser.Wishlist = wishlist;
            appUser.ImageId = 1;


            var result = await _userManager.CreateAsync(appUser, RegisterVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                };
                return View(RegisterVM);
            };

            var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());

            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                };
                return View(RegisterVM);
            };

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var confirmationLink = Url.Action("ConfirmEmail", "Auth", new { token, username = appUser.UserName }, HttpContext.Request.Scheme);

            SendEmail(appUser.Email, confirmationLink);

            return RedirectToAction("Index", controllerName: "Home");

        }

        public IActionResult SendEmail(string userEmail, string confirmationLink)
        {
            string from = "aliev.hsyn@gmail.com";
            string to = userEmail;
            string subject = "Confirm you email";
            string body = $"<a href=\"{confirmationLink}\">Click here for confirm your account!</a>";

            MailMessage mailMessage = new(
                from,
                to,
                subject,
                body
            );
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from, "vktvykutjpgmwvyz");
            try
            {
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                throw;
            }

            return Json("Ok");
        }

        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", controllerName: "Home");
        }

        public async Task<IActionResult> ConfirmEmail(string token, string username)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);

            if (appUser is null)
            {
                return Json("User could not Found");
            }

            var result = await _userManager.ConfirmEmailAsync(appUser, token);

            if (!result.Succeeded)
            {
                return Json("Your token is invalid");
            }

            return RedirectToAction("index", controllerName: "Home");
        }

        //public async Task CreateRoles()
        //{
        //    foreach (var item in Enum.GetValues(typeof(Roles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(item.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
        //        }
        //    }
        //}
    }
}

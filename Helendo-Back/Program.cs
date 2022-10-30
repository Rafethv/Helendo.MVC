using Business.Repositories;
using Business.Services;
using DAL.Abstracts;
using DAL.Data;
using DAL.Implementation;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddScoped<IImageService, ImageRepository>();
builder.Services.AddScoped<IImageDal, ImageRepositoryDal>();
builder.Services.AddScoped<IBlogDetailService, BlogDetailRepository>();
builder.Services.AddScoped<IBlogDetailDal, BlogDetailRepositoryDal>();
builder.Services.AddScoped<IBlogService, BlogRepository>();
builder.Services.AddScoped<IBlogDal, BlogRepositoryDal>();
builder.Services.AddScoped<ICartService, CartRepository>();
builder.Services.AddScoped<ICartDal, CartRepositoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryRepository>();
builder.Services.AddScoped<ICategoryDal, CategoryRepositoryDal>();
builder.Services.AddScoped<IProductDetailService, ProductDetailRepository>();
builder.Services.AddScoped<IProductDetailDal, ProductDetailRepositoryDal>();
builder.Services.AddScoped<IProductService, ProductRepository>();
builder.Services.AddScoped<IProductDal, ProductRepositoryDal>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryRepository>();
builder.Services.AddScoped<ISubCategoryDal, SubCategoryRepositoryDal>();
builder.Services.AddScoped<ITagService, TagRepository>();
builder.Services.AddScoped<ITagDal, TagRepositoryDal>();
builder.Services.AddScoped<IWishlistService, WishlistRepository>();
builder.Services.AddScoped<IWishlistDal, WishlistRepositoryDal>();


var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute
    (
        name: "admin",
        pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute
    (
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}"
    );
});

app.Run();

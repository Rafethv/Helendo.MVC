var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(_config.GetConnectionString("Default"));
//});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute
//    (
//        name: "admin",
//        pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
//    );
//});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute
    (
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}"
    );
});

app.Run();

using Microsoft.AspNetCore.Authentication.Cookies;
using P010Store.Data;
using P010Store.Service.Abstract;
using P010Store.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<IProductService, ProductService>(); // producta �zel yazd���m�z servis
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddSession(); // Uygulamada session kullanmam�z gerekirse
builder.Services.AddHttpClient(); // Web API yi kullanabilmemiz i�in gerekli servis
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Authentication : Oturum a�ma servisi
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // giri� yapma sayfas�
    x.AccessDeniedPath = "/AccessDenied"; // giri� yapan kullan�c�n�n admin yetkisi yoksa AccessDenied sayfas�na y�nlendir
    x.LogoutPath = "/Admin/Login/Logout"; // ��k�� sayfas�
    x.Cookie.Name = "Administrator"; // olu�acak kukinin ad�
    x.Cookie.MaxAge = TimeSpan.FromDays(1); // olu�acak kukinin ya�am s�resi
});
// Authorization : Yetkilendirme
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "User"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); // Uygulamada session kullanmam�z gerekirse

app.UseAuthentication(); // �nce oturum a�ma
app.UseAuthorization(); // sonra yetkilendirme

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "custom",
    pattern: "{customurl?}/{controller=Home}/{action=Index}/{id?}");

app.Run();

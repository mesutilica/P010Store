using P010Store.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // Entityframework iþlemlerini yapabilmek için bu satýrý ekliyoruz

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

app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


// Katmanlý Mimari Ýliþki Hiyerarþisi

/*
 * Web UI üzerinde veritabaný iþlemlerini yapabilmek için WebUI ýn dependencies(referanslarýna) Service katmanýný dependencies e sað týklayýp add project references diyerek açýlan pencereden Service katmanýna tik koyup ok butonuyla pencereyi kapatýp baðlantý kurduk.
 * Service katmaný da veritabaný iþlemlerini yapabilmek için Data katmanýna eriþmesi gerekiyor, yine dependencies e sað týklayýp add project references diyerek açýlan pencereden Data katmanýna iþaret koyup ekliyoruz.
 * Data katmanýnýn da entity lere eriþmesi gerekiyor ki class larý kulanarak veritabaný iþlemleri yapabilsin. yine ayný yolu izleyerek veya class larýn üzerine gelip ampul e týklayýp add project references diyerek data dan entities e eriþim vermemiz gerekiyor.
 */
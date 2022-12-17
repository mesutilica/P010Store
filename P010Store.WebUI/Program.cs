using P010Store.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // Entityframework i�lemlerini yapabilmek i�in bu sat�r� ekliyoruz

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


// Katmanl� Mimari �li�ki Hiyerar�isi

/*
 * Web UI �zerinde veritaban� i�lemlerini yapabilmek i�in WebUI �n dependencies(referanslar�na) Service katman�n� dependencies e sa� t�klay�p add project references diyerek a��lan pencereden Service katman�na tik koyup ok butonuyla pencereyi kapat�p ba�lant� kurduk.
 * Service katman� da veritaban� i�lemlerini yapabilmek i�in Data katman�na eri�mesi gerekiyor, yine dependencies e sa� t�klay�p add project references diyerek a��lan pencereden Data katman�na i�aret koyup ekliyoruz.
 * Data katman�n�n da entity lere eri�mesi gerekiyor ki class lar� kulanarak veritaban� i�lemleri yapabilsin. yine ayn� yolu izleyerek veya class lar�n �zerine gelip ampul e t�klay�p add project references diyerek data dan entities e eri�im vermemiz gerekiyor.
 */
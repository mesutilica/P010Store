using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;
using System.Security.Claims;

namespace P010Store.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<User> _service;

        public LoginController(IService<User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Admin/Logout")] // eğer uygulamada Admin/Logout url adresine istek gelirse, normalde adresi Admin/Login/Logout olan aşağıdaki metodu çalıştır
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); // kullanıcının oturumunu kapat-çıkış yap
            return Redirect("/Admin/Login"); // kullanıcıyı tekrar login giriş ekranına yönlendir
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var kullanici = await _service.FirstOrDefaultAsync(k => k.IsActive && k.Email == email && k.Password == password);
                if (kullanici != null)
                {
                    var kullaniciHaklari = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, kullanici.Name),
                        new Claim("Role", kullanici.IsAdmin ? "Admin" : "User"),
                        new Claim("UserId", kullanici.Id.ToString())
                    };
                    var kullaniciKimligi = new ClaimsIdentity(kullaniciHaklari, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin/Main");
                }
                else TempData["Mesaj"] = "Giriş Başarısız!";
            }
            catch (Exception hata)
            {
                // hata.Message
                // todo : hatalar db ye loglanacak
                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CafeteriaMVC.Data;
using CafeteriaMVC.Models;

namespace CafeteriaMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            byte[] senhaBytes = System.Text.Encoding.UTF8.GetBytes(senha ?? string.Empty);

            // Busca o usuário pelo e-mail primeiro
            var user = _context.Usuario.FirstOrDefault(u => u.Email == email);

            // Valida se o usuário existe e se os bytes da senha coincidem
            if (user != null && user.Senha != null && user.Senha.SequenceEqual(senhaBytes))
            {
                var claims = new List<System.Security.Claims.Claim> 
                { 
                    new System.Security.Claims.Claim(ClaimTypes.Name, user.Email) // 'Email' com E maiúsculo
                };
                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "E-mail ou senha inválidos!";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
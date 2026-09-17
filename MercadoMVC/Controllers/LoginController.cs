using Microsoft.AspNetCore.Mvc;
using MVC_Mercado.Data;
using MVC_Mercado.Services;

namespace MVC_Mercado.Controllers
{
    public class LoginController : Controller
    {
        private readonly MVC_MercadoContext _context;

        public LoginController(MVC_MercadoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Erro = "Preencha todos os campos.";
                return View("Index");
            }

            byte[] senhaDigitadaHash = HashService.GerarHashBytes(senha);

            var usuario = _context.Usuario.FirstOrDefault(usuario => usuario.Email == email);

            if(usuario == null)
            {
                ViewBag.Erro = "E-mail ou senha incorretos.";
                return View("Index");
            }

            if(!usuario.Senha.SequenceEqual(senhaDigitadaHash))
            {
                ViewBag.Erro = "E-mail ou senha incorretos.";
                return View("Index");
            }

            HttpContext.Session.SetString("NomeUsuario", usuario.NomeUsuario);
            HttpContext.Session.SetInt32("UsuarioID", usuario.UsuarioID);

            return RedirectToAction("Dashboard", "Dashboard");
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

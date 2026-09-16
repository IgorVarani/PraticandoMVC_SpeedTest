using AurumLab.Services;
using BibliotecaMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class LoginController : Controller
    {
        public readonly MVC_BibliotecaContext _context;
        
        public LoginController(MVC_BibliotecaContext context) { _context = context; }

        public IActionResult Index() { return View(); }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Erro = "Preencha todos os campos.";
                return View("index");
            }

            byte[] senhaDigitadaHash = HashService.GerarHashBytes(senha);

            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Email == email);

            if(usuario == null)
            {
                ViewBag.Erro = "E-mail ou senha incorretos.";
                return View("Index");
            }

            HttpContext.Session.SetString("UsuarioNome", usuario.NomeUsuario);
            HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioID);

            return RedirectToAction("Dashboard", "Dashboard");
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

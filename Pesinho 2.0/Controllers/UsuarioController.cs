using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pesinho_2._0.Models;
using Pesinho_2._0.Models.ViewsModels;
using System.Threading.Tasks;

namespace Pesinho_2._0.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password,
                    usuario.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }   
            }
            ModelState.AddModelError("", "Usuário/Senha inválidos!");
            return View(usuario);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegisterViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario()
                {
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    UserName = usuario.Email,
                    Email = usuario.Email,
                    Altura = (double)usuario.Altura
                };
                var result = await _userManager.CreateAsync(user, usuario.Password);
                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(user, "Member");
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Home", "Index");
                }
            }

            return View(usuario);
        }


    }
}
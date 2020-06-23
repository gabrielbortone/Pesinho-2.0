using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pesinho_2._0.Data;
using Pesinho_2._0.Models;

namespace Pesinho_2._0.Controllers
{
    [Authorize]
    public class PesoController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Usuario> _userManager;
        private readonly AppDbContext _context;

        public PesoController(AppDbContext context, Microsoft.AspNetCore.Identity.UserManager<Usuario> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(double peso)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Pesos.Add(new Peso()
                {
                    DataPesagem = DateTime.Now,
                    Pesagem = peso,
                    Usuario = await _userManager.GetUserAsync(HttpContext.User),
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("MostrarPesos", "Peso");
            }

            return View(peso);
        }
        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Peso peso)
        {
            if (ModelState.IsValid)
            {
                if (peso != null)
                {
                    _context.Update(peso);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MostrarPesos", "Peso");
                }
                return View(peso);
            }
            return View(peso);
        }

        public IActionResult Deletar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(Peso peso)
        {
            if (ModelState.IsValid)
            {
                if(peso != null)
                {
                    _context.Pesos.Remove(peso);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("MostrarPesos", "Peso");
            }
            return View(peso);
        }
        public async Task<IActionResult> MostrarPesos()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);
            var Pesos = _context.Pesos.Where(p => p.Usuario == usuario).ToList();
            return View(Pesos);
        }




    }
}
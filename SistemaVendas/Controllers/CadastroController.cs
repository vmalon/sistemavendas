using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class CadastroController : Controller
    {
        private ApplicationDbContext mContext;

        public CadastroController(ApplicationDbContext context)
        {
            mContext = context;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioViewModel);
            }
            else
            {
                try
                {
                    Usuario usuario = new Usuario();

                    var email = mContext.Usuario.Where(x => x.Email == usuarioViewModel.Email).Select(x => x.Email).FirstOrDefault();

                    if (email != null)
                    {
                        return View();
                    }
                    else
                    {
                        usuario.Email = usuarioViewModel.Email;
                        usuario.Nome = usuarioViewModel.Nome;
                        MD5 mD5 = MD5.Create();
                        usuario.Senha = Helpers.Criptografia.GetMd5Hash(mD5, usuarioViewModel.Senha);

                        mContext.Usuario.Add(usuario);
                        mContext.SaveChanges();

                        return RedirectToAction("Index", "Login");
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
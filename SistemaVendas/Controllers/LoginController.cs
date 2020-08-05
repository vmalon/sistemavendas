using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Helpers;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext mContext;
        private IHttpContextAccessor HttpContextAccessor;

        public LoginController(ApplicationDbContext _context, IHttpContextAccessor httpContextAccessor)
        {
            mContext = _context;
            HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(int? status)
        {
            if (status == 0)
            {
                HttpContextAccessor.HttpContext.Session.Clear();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            else
            {
                try
                {
                    MD5 Md5Hash = MD5.Create();

                    var senhaMD5 = Criptografia.GetMd5Hash(Md5Hash, loginViewModel.Senha);

                    var usuario = mContext.Usuario.Where(x => x.Email == loginViewModel.Email && x.Senha == senhaMD5).FirstOrDefault();

                    if (usuario == null)
                    {
                        ViewData["ErroLogin"] = "O  Email ou senha informado não existe no sistema!";
                        return View(loginViewModel);
                    }
                    else
                    {
                        //Manter os dados do usuário em sessão
                        HttpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                        HttpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                        HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                        HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }


        }

    }
}
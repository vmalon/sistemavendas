using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class HomeController : Controller
    {

        protected ApplicationDbContext Repositorio;

        public HomeController(ApplicationDbContext repositorio)
        {
            Repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public void UploadArquivo(string arquivo)
        {
            try
            {
                var ServicoUploadApi = new ServicoUploadApi();
                var file = new FileInfo(arquivo);
                var fileList = new List<FileInfo>();
                fileList.Add(file);
                ServicoUploadApi.UploadArquivos(fileList);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}

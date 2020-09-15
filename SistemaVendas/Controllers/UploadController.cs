using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    public class UploadController : Controller
    {


        public IActionResult Index()
        {

            List<FileInfo> listaFileInfo = new List<FileInfo>() { new FileInfo("C:/Users/Vinícius/Downloads/Erro Sistema TCE.png") };
            try
            {
                ServicoUploadApi ServicoUploadApi = new ServicoUploadApi();

                ServicoUploadApi.UploadArquivos(listaFileInfo);
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }
    }
}
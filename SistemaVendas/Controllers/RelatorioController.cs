using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class RelatorioController : Controller
    {
        private string labels;
        private string valores;
        private string cores    ;

        private ApplicationDbContext mContext;

        public RelatorioController(ApplicationDbContext _context)
        {
            mContext = _context;
        }

        public IActionResult Grafico()
        {

            try
            {
                var lista = mContext.VendaProdutos
                    .GroupBy(x => x.CodigoProduto)
                        .Select(y => new GraficoViewModel
                        {
                            CodigoProduto = y.First().CodigoProduto,
                            Descricao = y.First().Produto.Descricao,
                            QuantidadeTotal = y.Sum(z => z.Quantidade)
                        }).ToList();


                var random = new Random();

                foreach (var item in lista)
                {
                    labels += $"'{item.Descricao}',";
                    valores += $"{item.QuantidadeTotal},";
                    cores += $"'{String.Format("#{0:x6}", random.Next(0x1000000))}',";
                }

                ViewBag.Labels = labels;
                ViewBag.Valores = valores;
                ViewBag.Cores = cores;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }




            return View();
        }
    }
}
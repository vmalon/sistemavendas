using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        private ApplicationDbContext mContext;

        public VendaController(ApplicationDbContext dbContext)
        {
            mContext = dbContext;
        }

        public IActionResult Index()
        {
            ListaClientes();
            ListaProdutos();

            return View();
        }

        private IEnumerable<SelectListItem> ListaClientes()
        {
            List<SelectListItem> listaClientes = new List<SelectListItem>();

            listaClientes.Add(new SelectListItem
            {
                Value = string.Empty,
                Text = "Selecione"
            });

            foreach (var item in mContext.Cliente.ToList())
            {
                listaClientes.Add(new SelectListItem
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                });
            }

            return listaClientes;
        }

        public IEnumerable<SelectListItem> ListaProdutos()
        {
            List<SelectListItem> listaProdutos = new List<SelectListItem>();

            listaProdutos.Add(new SelectListItem
            {
                Value = string.Empty,
                Text = "Selecione"
            });

            foreach (var item in mContext.Produto.ToList())
            {
                listaProdutos.Add(new SelectListItem
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return listaProdutos;
        }

    }
}
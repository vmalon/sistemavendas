using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;

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
            IEnumerable<Venda> listaVendas = mContext.Venda.ToList();

            ListaClientes();
            ListaProdutos();

            return View(listaVendas);
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

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            viewModel.ListaClientes = ListaClientes();
            viewModel.ListaProdutos = ListaProdutos();

            if (id != null)
            {
                var entidade = mContext.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Data = entidade.Data;
                viewModel.Total = entidade.Total;
                viewModel.CodigoCliente = entidade.CodigoCliente;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel venda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Venda objVenda = new Venda()
                    {
                        Codigo = (venda.Codigo != null) ? venda.Codigo : null,
                        Data = (DateTime)venda.Data,
                        Total = venda.Total,
                        CodigoCliente = (int)venda.CodigoCliente,
                        Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(venda.JsonProdutos)
                    };


                    if (venda.Codigo != null)
                    {
                        mContext.Entry(objVenda).State = EntityState.Modified;
                    }
                    else
                    {
                        mContext.Add(objVenda);
                    }

                    mContext.SaveChanges();
                    mContext.Dispose();
                    return RedirectToAction("Index");
                }
                else
                {
                    venda.ListaClientes = ListaClientes();
                    venda.ListaProdutos = ListaProdutos();
                    return View(venda);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            try
            {
                Venda venda = mContext.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                mContext.Attach(venda);
                mContext.Remove(venda);
                mContext.SaveChanges();
                mContext.Dispose();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("BuscaPrecoProduto/{CodigoProduto}")]
        public decimal BuscaPrecoProduto(int codigoProduto)
        {
            try
            {
                return mContext.Produto.Where(x => x.Codigo == codigoProduto).Select(x => x.Valor).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaVendas.DAL;
using SistemaVendas.Dominio.Entidades;
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
            IEnumerable<Venda> listaVendas = (from v in mContext.Venda
                                              join c in mContext.Cliente
                                              on v.CodigoCliente equals c.Codigo
                                              select new Venda
                                              {
                                                  Codigo = v.Codigo,
                                                  CodigoCliente = v.CodigoCliente,
                                                  Data = v.Data,
                                                  Total = v.Total,
                                                  Cliente = new Cliente
                                                  {
                                                      Nome = c.Nome
                                                  }
                                              }).OrderByDescending(x => x.Total).ToList();

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
                var venda = mContext.Venda.Where(x => x.Codigo == id).Include(z => z.Produtos).FirstOrDefault();

                viewModel.Codigo = venda.Codigo;
                viewModel.Data = venda.Data;
                viewModel.Total = venda.Total;
                viewModel.CodigoCliente = venda.CodigoCliente;
                viewModel.Produtos = venda.Produtos;
              
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

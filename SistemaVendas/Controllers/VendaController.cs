using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Aplicacao.Servico.Interfaces;
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
        private readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;

        public VendaController(IServicoAplicacaoVenda servicoAplicacaoVenda)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
        }

        public IActionResult Index()
        {
            //IEnumerable<Venda> listaVendas = (from v in mContext.Venda
            //                                  join c in mContext.Cliente
            //                                  on v.CodigoCliente equals c.Codigo
            //                                  select new Venda
            //                                  {
            //                                      Codigo = v.Codigo,
            //                                      CodigoCliente = v.CodigoCliente,
            //                                      Data = v.Data,
            //                                      Total = v.Total,
            //                                      Cliente = new Cliente
            //                                      {
            //                                          Nome = c.Nome
            //                                      }
            //                                  }).OrderByDescending(x => x.Total).ToList();

            return View(ServicoAplicacaoVenda.ListarVendas());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            viewModel.ListaClientes = ServicoAplicacaoVenda.ListarClientes();
            viewModel.ListaProdutos = ServicoAplicacaoVenda.ListarProdutos();
            var dataAtual = DateTime.Now.ToString("dd/MM/yyyy");
            viewModel.Data = Convert.ToDateTime(dataAtual);

            if (id != null)
            {
                viewModel = ServicoAplicacaoVenda.BuscarVenda((int)id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel vendaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicoAplicacaoVenda.CadastrarVenda(vendaViewModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    vendaViewModel.ListaClientes = ServicoAplicacaoVenda.ListarClientes();
                    vendaViewModel.ListaProdutos = ServicoAplicacaoVenda.ListarProdutos();
                    return View(vendaViewModel);
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
                ServicoAplicacaoVenda.ExcluirVenda(id);
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
                return ServicoAplicacaoVenda.BuscaPrecoProduto(codigoProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

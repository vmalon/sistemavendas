using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;

        public ProdutoController(IServicoAplicacaoProduto servicoAplicacaoProduto)
        {
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
        }

        public IActionResult Index()
        {
            IEnumerable<ProdutoViewModel> lista = ServicoAplicacaoProduto.ListarProdutos();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            produtoViewModel.ListaCategorias = ServicoAplicacaoProduto.ListaCategorias();

            if (id != null)
            {
                produtoViewModel = ServicoAplicacaoProduto.BuscarProduto((int)id);
                return View(produtoViewModel);
            };

            return View(produtoViewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicoAplicacaoProduto.CadastrarProduto(produto);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(produto);
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
                ServicoAplicacaoProduto.ExcluirProduto(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ProdutoController : Controller
    {
        protected ApplicationDbContext mContext;

        public ProdutoController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Produto> lista = mContext.Produto.Include(x => x.Categoria).ToList();

            //Libera a memória do acesso ao Entity
            mContext.Dispose();
            return View(lista);
        }

        private IEnumerable<SelectListItem> ListaCategorias()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = "Selecione"
            });

            foreach (var item in mContext.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return lista;
        }



        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.ListaCategorias = ListaCategorias();

            if (id != null)
            {
                var entidade = mContext.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
                viewModel.Quantidade = entidade.Quantidade;
                viewModel.Valor = entidade.Valor;
                viewModel.CodigoCategoria = entidade.CodigoCategoria;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto objProduto = new Produto()
                    {
                        Codigo = (produto.Codigo != null) ? produto.Codigo : null,
                        Descricao = produto.Descricao,
                        Quantidade = produto.Quantidade,
                        Valor = (decimal)produto.Valor,
                        CodigoCategoria = (int)produto.CodigoCategoria,
                    };

                    if (produto.Codigo != null)
                    {
                        mContext.Entry(objProduto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    else
                    {
                        mContext.Add(objProduto);
                    }

                    mContext.SaveChanges();
                    mContext.Dispose();
                    return RedirectToAction("Index");
                }
                else
                {
                    produto.ListaCategorias = ListaCategorias();
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
                Produto produto = mContext.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                mContext.Attach(produto);
                mContext.Remove(produto);
                mContext.SaveChanges();
                mContext.Dispose();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
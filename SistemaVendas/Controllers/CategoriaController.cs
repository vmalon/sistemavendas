using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext mContext;

        public CategoriaController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            //Libera a memória do acesso ao Entity
            mContext.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if (id != null)
            {
                var entidade = mContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categoria objCategoria = new Categoria()
                    {
                        Codigo = (categoria.Codigo != null) ? categoria.Codigo : null,
                        Descricao = categoria.Descricao
                    };

                    if (categoria.Codigo != null)
                    {
                        mContext.Entry(objCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    else
                    {
                        mContext.Add(objCategoria);
                    }

                    mContext.SaveChanges();
                    mContext.Dispose();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categoria);
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
                Categoria categoria = mContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                mContext.Attach(categoria);
                mContext.Remove(categoria);
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
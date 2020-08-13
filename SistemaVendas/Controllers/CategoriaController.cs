using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoCategoria.ListarCategorias());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel objCategoriaViewModel = new CategoriaViewModel();
            if (id != null)
            {
                objCategoriaViewModel = ServicoAplicacaoCategoria.BuscarCategoria((int)id);
            }

            return View(objCategoriaViewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicoAplicacaoCategoria.CadastrarCategoria(categoria);
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
                ServicoAplicacaoCategoria.ExcluirCategoria(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
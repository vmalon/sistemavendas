using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ClienteController : Controller
    {
        IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            var listaClientes = ServicoAplicacaoCliente.ListarClientes();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel clienteViewModel = new ClienteViewModel();

            if (id != null)
            {
                clienteViewModel = ServicoAplicacaoCliente.BuscarCliente((int)id);
            }

            return View(clienteViewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicoAplicacaoCliente.CadastrarCliente(cliente);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cliente);
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
                ServicoAplicacaoCliente.ExcluirCliente(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
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
    public class ClienteController : Controller
    {
        protected ApplicationDbContext mContext;

        public ClienteController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = mContext.Cliente.ToList();
            //Libera a memória do acesso ao Entity
            mContext.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            if (id != null)
            {
                var entidade = mContext.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Nome = entidade.Nome;
                viewModel.CNPJ_CPF = entidade.CNPJ_CPF;
                viewModel.Email = entidade.Email;
                viewModel.Celular = entidade.Celular;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente objCliente = new Cliente()
                    {
                        Codigo = (cliente.Codigo != null) ? cliente.Codigo : null,
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Celular = cliente.Celular,
                        CNPJ_CPF = cliente.CNPJ_CPF,
                    };

                    if (cliente.Codigo != null)
                    {
                        mContext.Entry(objCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    else
                    {
                        mContext.Add(objCliente);
                    }

                    mContext.SaveChanges();
                    mContext.Dispose();
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
                Cliente cliente = mContext.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                mContext.Attach(cliente);
                mContext.Remove(cliente);
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
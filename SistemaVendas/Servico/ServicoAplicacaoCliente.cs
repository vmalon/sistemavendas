using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente ServicoCliente;

        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            ServicoCliente = servicoCliente;
        }

        public IEnumerable<ClienteViewModel> ListarClientes()
        {
            var listaClientes = ServicoCliente.ListarRegistros();

            List<ClienteViewModel> listaClienteViewModel = new List<ClienteViewModel>();

            foreach (var cliente in listaClientes)
            {
                listaClienteViewModel.Add(new ClienteViewModel()
                {
                    Codigo = cliente.Codigo,
                    Celular = cliente.Celular,
                    CNPJ_CPF = cliente.CNPJ_CPF,
                    Email = cliente.Email,
                    Nome = cliente.Nome
                });
            }
            return listaClienteViewModel;
        }

        public ClienteViewModel BuscarCliente(int id)
        {
            var cliente = ServicoCliente.BuscarRegistro(id);

            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                Codigo = cliente.Codigo,
                Celular = cliente.Celular,
                CNPJ_CPF = cliente.CNPJ_CPF,
                Email = cliente.Email,
                Nome = cliente.Nome
            };

            return clienteViewModel;
        }

        public void CadastrarCliente(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = new Cliente()
            {
                Codigo = clienteViewModel.Codigo,
                Celular = clienteViewModel.Celular,
                CNPJ_CPF = clienteViewModel.CNPJ_CPF,
                Email = clienteViewModel.Email,
                Nome = clienteViewModel.Nome
            };

            ServicoCliente.Cadastrar(cliente);
        }

        public void ExcluirCliente(int id)
        {
            ServicoCliente.ExcluirRegistro(id);
        }
    }
}

using Dominio.Interfaces;
using Dominio.Repositorio;
using Repositorio;
using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        IRepositorioCliente RepositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            RepositorioCliente = repositorioCliente;
        }

        public Cliente BuscarRegistro(int id)
        {
            return RepositorioCliente.Read(id);
        }

        public void Cadastrar(Cliente cliente)
        {
            RepositorioCliente.Create(cliente);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioCliente.Delete(id);
        }

        public IEnumerable<Cliente> ListarRegistros()
        {
            return RepositorioCliente.Read();
        }
    }
}

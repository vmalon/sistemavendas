using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class ServicoVendaProdutos : IServicoVendaProdutos
    {
        IRepositorioVendaProdutos RepositorioVendaProdutos;

        public ServicoVendaProdutos(IRepositorioVendaProdutos repositorioVendaProdutos)
        {
            RepositorioVendaProdutos = repositorioVendaProdutos;
        }

        public IEnumerable<VendaProdutos> Read()
        {
            return RepositorioVendaProdutos.Read();
        }
    }
}

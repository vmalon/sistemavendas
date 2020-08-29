using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;


namespace Dominio.Servicos
{
    public class ServicoVenda : IServicoVenda
    {
        private readonly IRepositorioVenda RepositorioVenda;

        public ServicoVenda(IRepositorioVenda repositorioVenda)
        {
            RepositorioVenda = repositorioVenda;
        }

        public Venda BuscarRegistro(int id)
        {
            return RepositorioVenda.Read(id);
        }

        public void Cadastrar(Venda venda)
        {
            RepositorioVenda.Create(venda);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioVenda.Delete(id);
        }

        public IEnumerable<Venda> ListarRegistros()
        {
            return RepositorioVenda.Read();
        }
    }
}

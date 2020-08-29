using SistemaVendas.Dominio.Entidades;
using Dominio.Interfaces;
using System.Collections.Generic;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
        private readonly IRepositorioProduto RepositorioProduto;

        public ServicoProduto(IRepositorioProduto repositorioProduto)
        {
            RepositorioProduto = repositorioProduto;
        }

        public Produto BuscarRegistro(int id)
        {
            return RepositorioProduto.Read(id);
        }

        public void Cadastrar(Produto entidade)
        {
            RepositorioProduto.Create(entidade);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioProduto.Delete(id);
        }

        public IEnumerable<Produto> ListarRegistros()
        {
            return RepositorioProduto.Read();
        }
    }
}

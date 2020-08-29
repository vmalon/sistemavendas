using Repositorio;
using SistemaVendas.Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorioProduto : IRepositorioGenerico<Produto>
    {
        new IEnumerable<Produto> Read();
    }
}

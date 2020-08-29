using SistemaVendas.Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorioVendaProdutos
    {
        IEnumerable<VendaProdutos> Read();
    }
}

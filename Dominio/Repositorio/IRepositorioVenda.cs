using Repositorio;
using SistemaVendas.Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorioVenda : IRepositorioGenerico<Venda>
    {
        new Venda Read(int id);
        new void Delete(int id);
    }
}

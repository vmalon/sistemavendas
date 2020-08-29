using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVendas.Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class ServicoCategoria : IServicoCategoria
    {
        IRepositorioCategoria RepositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
        {
            RepositorioCategoria = repositorioCategoria;
        }

        public IEnumerable<Categoria>ListarRegistros()
        {
            return RepositorioCategoria.Read();
        }

        public void Cadastrar(Categoria categoria)
        {
            RepositorioCategoria.Create(categoria);
        }

        public Categoria BuscarRegistro(int id)
        {
            return RepositorioCategoria.Read(id);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioCategoria.Delete(id);
        }
    }
}

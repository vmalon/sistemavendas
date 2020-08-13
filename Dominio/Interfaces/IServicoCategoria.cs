using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicoCategoria
    {
        IEnumerable<Categoria> ListarCategorias();

        void Cadastrar(Categoria categoria);

        Categoria BuscarCategoria(int id);

        void ExcluirCategoria(int id);

    }
}

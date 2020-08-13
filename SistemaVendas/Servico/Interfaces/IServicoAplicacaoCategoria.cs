using SistemaVendas.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<CategoriaViewModel> ListarCategorias();

        CategoriaViewModel BuscarCategoria(int id);

        void CadastrarCategoria(CategoriaViewModel categoria);

        void ExcluirCategoria(int id);
    }
}

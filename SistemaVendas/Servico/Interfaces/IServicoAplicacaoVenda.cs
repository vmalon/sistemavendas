using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<VendaViewModel> ListarVendas();

        VendaViewModel BuscarVenda(int id);

        void CadastrarVenda(VendaViewModel vendaViewModel);

        void ExcluirVenda(int id);

        decimal BuscaPrecoProduto(int id);

        List<SelectListItem> ListarClientes(); 

        List<SelectListItem> ListarProdutos(); 

    }
}

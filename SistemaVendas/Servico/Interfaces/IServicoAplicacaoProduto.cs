using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<ProdutoViewModel> ListarProdutos();

        ProdutoViewModel BuscarProduto(int id);

        void CadastrarProduto(ProdutoViewModel produtoViewModel);

        void ExcluirProduto(int id);

        List<SelectListItem> ListaCategorias();
    }
}

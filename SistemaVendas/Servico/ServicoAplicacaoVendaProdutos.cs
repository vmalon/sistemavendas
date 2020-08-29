using System.Collections.Generic;
using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using SistemaVendas.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVendaProdutos : IServicoAplicacaoVendaProdutos
    {
        IServicoVendaProdutos ServicoVendaProdutos;

        public ServicoAplicacaoVendaProdutos(IServicoVendaProdutos servicoVendaProdutos)
        {
            ServicoVendaProdutos = servicoVendaProdutos;
        }

        public List<GraficoViewModel> ListaProdutosGrafico()
        {
            var lista = ServicoVendaProdutos.Read();

            List<GraficoViewModel> listaGrafico = new List<GraficoViewModel>();

            foreach (var item in lista)
            {
                listaGrafico.Add(new GraficoViewModel()
                {
                    CodigoProduto = item.CodigoProduto,
                    Descricao = item.Produto.Descricao,
                    QuantidadeTotal = item.Quantidade
                });
            };

            return listaGrafico;
        }
    }
}

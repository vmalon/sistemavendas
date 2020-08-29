using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto ServicoProduto;
        private readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public ServicoAplicacaoProduto(IServicoProduto servicoProduto, IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoProduto = servicoProduto;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IEnumerable<ProdutoViewModel> ListarProdutos()
        {
            var listaProdutos = ServicoProduto.ListarRegistros();

            List<ProdutoViewModel> listaProdutoViewModel = new List<ProdutoViewModel>();

            foreach (var produto in listaProdutos)
            {
                listaProdutoViewModel.Add(new ProdutoViewModel()
                {
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao,
                    Quantidade = produto.Quantidade,
                    Valor = produto.Valor,
                    CodigoCategoria = produto.CodigoCategoria,
                    DescricaoCategoria = produto.Categoria.Descricao

                });
            }
            return listaProdutoViewModel;
        }

        public ProdutoViewModel BuscarProduto(int id)
        {
            var produto = ServicoProduto.BuscarRegistro(id);

            ProdutoViewModel produtoViewModel = new ProdutoViewModel()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                Valor = produto.Valor,
                CodigoCategoria = produto.CodigoCategoria,
                ListaCategorias = ListaCategorias()
            };

            return produtoViewModel;
        }

        public void CadastrarProduto(ProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto()
            {
                Codigo = produtoViewModel.Codigo,
                Descricao = produtoViewModel.Descricao,
                Quantidade = produtoViewModel.Quantidade,
                Valor = (decimal)produtoViewModel.Valor,
                CodigoCategoria = (int)produtoViewModel.CodigoCategoria
            };

            ServicoProduto.Cadastrar(produto);
        }

        public void ExcluirProduto(int id)
        {
            ServicoProduto.ExcluirRegistro(id);
        }

        public List<SelectListItem> ListaCategorias()
        {
            var listaCategorias = ServicoAplicacaoCategoria.ListarCategorias();

            List<SelectListItem> listaItemsCategoria = new List<SelectListItem>();

            listaItemsCategoria.Add(new SelectListItem()
            {
                Text = "Selecione",
                Value = "Selecione",
            });

            foreach (var categoria in listaCategorias)
            {
                listaItemsCategoria.Add(new SelectListItem()
                {
                    Text = categoria.Descricao,
                    Value = categoria.Codigo.ToString()
                });
            }

            return listaItemsCategoria;
        }
    }
}

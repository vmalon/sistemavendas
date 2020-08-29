using System;
using System.Collections.Generic;
using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda ServicoVenda;
        private readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;
        private readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;

        public ServicoAplicacaoVenda(IServicoVenda servicoVenda, IServicoAplicacaoCliente servicoAplciacaoCliente, IServicoAplicacaoProduto servicoAplicacaoProduto)
        {
            ServicoVenda = servicoVenda;
            ServicoAplicacaoCliente = servicoAplciacaoCliente;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
        }

        public VendaViewModel BuscarVenda(int id)
        {
            var venda = ServicoVenda.BuscarRegistro(id);

            var listaJsonProdutos =
            JsonConvert.SerializeObject(venda.Produtos, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            VendaViewModel vendaViewModel = new VendaViewModel()
            {
                Codigo = venda.Codigo,
                CodigoCliente = venda.CodigoCliente,
                Data = venda.Data,
                Produtos = venda.Produtos,
                JsonProdutos = listaJsonProdutos,
                Total = (double)venda.Total,
                ListaClientes = ListarClientes(),
                ListaProdutos = ListarProdutos()
            };

            return vendaViewModel;
        }

        public void CadastrarVenda(VendaViewModel vendaViewModel)
        {
            var listaVendaProdutos = DeserializaListaVendaProdutos(vendaViewModel.JsonProdutos);

            Venda venda = new Venda()
            {
                Codigo = vendaViewModel.Codigo,
                CodigoCliente = (int)vendaViewModel.CodigoCliente,
                Data = vendaViewModel.Data,
                Produtos = listaVendaProdutos,
                Total = (decimal)vendaViewModel.Total
            };

            ServicoVenda.Cadastrar(venda);
        }

        public void ExcluirVenda(int id)
        {
            ServicoVenda.ExcluirRegistro(id);
        }

        public IEnumerable<VendaViewModel> ListarVendas()
        {
            var listaVendas = ServicoVenda.ListarRegistros();
            List<VendaViewModel> listaVendaViewModel = new List<VendaViewModel>();

            foreach (var venda in listaVendas)
            {
                listaVendaViewModel.Add(new VendaViewModel()
                {
                    Codigo = venda.Codigo,
                    CodigoCliente = venda.CodigoCliente,
                    Data = venda.Data,
                    Produtos = venda.Produtos,
                    Total = (double)venda.Total,
                    Cliente = venda.Cliente
                });
            }
            return listaVendaViewModel;
        }

        private ICollection<VendaProdutos> DeserializaListaVendaProdutos(string json)
        {
            try
            {
                var listaProdutos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(json);
                return listaProdutos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public decimal BuscaPrecoProduto(int id)
        {
            return (int)ServicoAplicacaoProduto.BuscarProduto(id).Valor;
        }

        public List<SelectListItem> ListarClientes()
        {
            var listaClientes = ServicoAplicacaoCliente.ListarClientes();

            List<SelectListItem> ListaDropDownClientes = new List<SelectListItem>();

            ListaDropDownClientes.Add(new SelectListItem()
            {
                Text = "Selecione",
                Value = "0"
            });

            foreach (var cliente in listaClientes)
            {
                ListaDropDownClientes.Add(new SelectListItem()
                {
                    Text = cliente.Nome,
                    Value = cliente.Codigo.ToString()
                });
            }

            return ListaDropDownClientes;
        }

        public List<SelectListItem> ListarProdutos()
        {
            var listaProdutos = ServicoAplicacaoProduto.ListarProdutos();

            List<SelectListItem> ListaDropDownProdutos = new List<SelectListItem>();

            ListaDropDownProdutos.Add(new SelectListItem()
            {
                Text = "Selecione",
                Value = "0"
            });

            foreach (var produto in listaProdutos)
            {
                ListaDropDownProdutos.Add(new SelectListItem()
                {
                    Text = produto.Descricao,
                    Value = produto.Codigo.ToString()
                });
            }

            return ListaDropDownProdutos;
        }
    }
}

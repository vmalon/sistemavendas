using Dominio.Interfaces;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria ServicoCategoria;

        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)    
        {
            ServicoCategoria = servicoCategoria;
        }


        public IEnumerable<CategoriaViewModel> ListarCategorias()
        {
            var listaCategorias = ServicoCategoria.ListarRegistros();

            List<CategoriaViewModel> listaCategoriaViewModel = new List<CategoriaViewModel>();

            foreach (var item in listaCategorias)
            {
                CategoriaViewModel categoria = new CategoriaViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };

                listaCategoriaViewModel.Add(categoria);
            }

            return listaCategoriaViewModel;
        }

        public CategoriaViewModel BuscarCategoria(int id)
        {
            var registro = ServicoCategoria.BuscarRegistro(id);

            CategoriaViewModel objCategoriaViewModel = new CategoriaViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao
            };

            return objCategoriaViewModel;
        }

        public void CadastrarCategoria(CategoriaViewModel categoria)
        {
            Categoria objCategoria = new Categoria
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            ServicoCategoria.Cadastrar(objCategoria);
        }

        public void ExcluirCategoria(int id)
        {
            ServicoCategoria.ExcluirRegistro(id);
        }

    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class VendaViewModel
    {
        public int? Codigo { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Informe a Data da Venda")]
        public DateTime Data { get; set; }

        public double Total { get; set; }

        [Required(ErrorMessage = "Informe o Cliente da Venda")]
        public int? CodigoCliente { get; set; }

        public IEnumerable<SelectListItem> ListaProdutos { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        public ICollection<VendaProdutos> Produtos { get; set; }

        [Required(ErrorMessage = "Adicione uma ou mais vendas antes de salvar")]
        public string JsonProdutos { get; set; }
    }
}

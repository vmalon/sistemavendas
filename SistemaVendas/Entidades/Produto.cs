using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Entidades
{
    public class Produto
    {
        [Key]
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public decimal Valor { get; set; }
        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<VendaProdutos> Vendas { get; set; }
    }
}

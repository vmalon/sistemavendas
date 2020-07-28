using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Entidades
{
    public class VendaProdutos
    {
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }
        public double Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}

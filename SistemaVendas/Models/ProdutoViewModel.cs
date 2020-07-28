using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Informe a descricao do produto")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a quantidade em estoque do produto")]
        public double Quantidade { get; set; }
        [Required(ErrorMessage = "Informe o valor do produto")]
        [Range(0.1,Double.PositiveInfinity)]
        public decimal? Valor { get; set; }
        [Required(ErrorMessage = "Informe a categoria do produto")]
        public int? CodigoCategoria { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}

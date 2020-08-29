using Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaVendas.Dominio.Entidades
{
    public class Categoria : EntityBase
    {
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}

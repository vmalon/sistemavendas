using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicoVendaProdutos
    {
        IEnumerable<VendaProdutos> Read();
    }
}

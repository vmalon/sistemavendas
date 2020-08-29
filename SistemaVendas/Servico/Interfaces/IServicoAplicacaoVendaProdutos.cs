using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVendaProdutos
    {
        List<GraficoViewModel> ListaProdutosGrafico();
    }
}

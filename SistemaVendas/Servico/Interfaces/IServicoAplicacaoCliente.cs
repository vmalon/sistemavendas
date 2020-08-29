using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        IEnumerable<ClienteViewModel> ListarClientes();

        ClienteViewModel BuscarCliente(int id);

        void CadastrarCliente(ClienteViewModel clienteViewModel);

        void ExcluirCliente(int id);

    }
}

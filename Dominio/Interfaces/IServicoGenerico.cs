using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IServicoGenerico<TEntidade> where TEntidade : class
    {
        void Cadastrar(TEntidade entidade);

        TEntidade BuscarRegistro(int id);

        IEnumerable<TEntidade> ListarRegistros();

        void ExcluirRegistro(int id);

    }
}

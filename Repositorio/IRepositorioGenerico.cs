using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public interface IRepositorioGenerico<TEntidade> where TEntidade : class
    {
        void Create(TEntidade Entity);

        IEnumerable<TEntidade> Read();

        TEntidade Read(int id);

        void Delete(int id);

    }
}

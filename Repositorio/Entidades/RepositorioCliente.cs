using Dominio.Repositorio;
using Repositorio.Contexto;
using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Entidades
{
    public class RepositorioCliente : RepositorioGenerico<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}

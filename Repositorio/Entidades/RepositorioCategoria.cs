using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVendas.Dominio.Entidades;


namespace Repositorio.Entidades
{
    public class RepositorioCategoria : RepositorioGenerico<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}

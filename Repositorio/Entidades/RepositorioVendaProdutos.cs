using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVendas.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;


namespace Repositorio.Entidades
{
    public class RepositorioVendaProdutos : DbContext, IRepositorioVendaProdutos
    {
        private DbContext Db;
        private DbSet<VendaProdutos> DbSetContext;

        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        public RepositorioVendaProdutos(ApplicationDbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<VendaProdutos>();
        }

        public IEnumerable<VendaProdutos> Read()
        {
            return DbSetContext.Include(x => x.Produto).AsNoTracking().ToList();
        }
    }
}

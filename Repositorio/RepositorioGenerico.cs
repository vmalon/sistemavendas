using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repositorio
{
    public abstract class RepositorioGenerico<TEntidade> : DbContext, IRepositorioGenerico<TEntidade> where TEntidade : EntityBase, new()
    {
        DbContext Db;
        DbSet<TEntidade> DbSetContext;

        public RepositorioGenerico(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<TEntidade>();
        }

        public DbSet<TEntidade> Entidade { get; set; }


        public void Create(TEntidade Entity)
        {
            if (Entity.Codigo == null)
            {
                DbSetContext.Add(Entity);
            }
            else
            {
                Db.Entry(Entity).State = EntityState.Modified;
            }

            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entidade = new TEntidade { Codigo = id };
            DbSetContext.Attach(entidade);
            DbSetContext.Remove(entidade);
            Db.SaveChanges();

        }

        public IEnumerable<TEntidade> Read()
        {
            return DbSetContext.AsNoTracking().ToList();

        }

        public TEntidade Read(int id)
        {
            return DbSetContext.Where(x => x.Codigo == id).FirstOrDefault();
        }
    }
}

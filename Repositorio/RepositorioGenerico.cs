using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repositorio
{
    public abstract class RepositorioGenerico<TEntidade> : DbContext, IRepositorioGenerico<TEntidade> where TEntidade : EntityBase, new()
    {
        protected DbContext Db;
        protected DbSet<TEntidade> DbSetContext;

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

        public virtual void Delete(int id)
        {
            var entidade = new TEntidade { Codigo = id };
            DbSetContext.Attach(entidade);
            DbSetContext.Remove(entidade);
            Db.SaveChanges();
        }

        public virtual IEnumerable<TEntidade> Read()
        {
            return DbSetContext.AsNoTracking().ToList();
        }

        public virtual TEntidade Read(int id)
        {
            return DbSetContext.Where(x => x.Codigo == id).FirstOrDefault();
        }
    }
}

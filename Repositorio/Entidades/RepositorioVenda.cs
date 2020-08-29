using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVendas.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioVenda : RepositorioGenerico<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext dbContext) : base(dbContext) { }

        DbSet<VendaProdutos> dbSetVendaProdutos;
        DbSet<Produto> dbSetProdutos;
        DbSet<Cliente> dbSetCliente;

        public override IEnumerable<Venda> Read()
        {
            dbSetVendaProdutos = Db.Set<VendaProdutos>();
            dbSetProdutos = Db.Set<Produto>();
            dbSetCliente = Db.Set<Cliente>();
            var listaVendas = (from venda in DbSetContext
                               join vendaProdutos in dbSetVendaProdutos
                               on venda.Codigo equals vendaProdutos.CodigoVenda
                               join cliente in dbSetCliente
                               on venda.CodigoCliente equals cliente.Codigo
                               select new Venda()
                               {
                                   Cliente = new Cliente()
                                   {
                                       Nome = cliente.Nome
                                   },
                                   Codigo = venda.Codigo,
                                   CodigoCliente = venda.CodigoCliente,
                                   Data = venda.Data,
                                   Total = venda.Total
                               }).OrderByDescending(x => x.Total).Distinct().ToList();

            return listaVendas;
        }

        public override Venda Read(int id)
        {
            dbSetVendaProdutos = Db.Set<VendaProdutos>();
            dbSetProdutos = Db.Set<Produto>();

            var produtos = DbSetContext.Where(x => x.Codigo == id).Include(x => x.Produtos).FirstOrDefault();

            foreach (var item in produtos.Produtos)
            {
                item.Produto = dbSetProdutos.Where(x => x.Codigo == item.CodigoProduto).FirstOrDefault();
            }


            var objVenda = (from venda in DbSetContext
                            join vendaProdutos in dbSetVendaProdutos
                            on venda.Codigo equals vendaProdutos.CodigoVenda
                            join produto in dbSetProdutos
                            on vendaProdutos.CodigoProduto equals produto.Codigo
                            select new Venda
                            {
                                Codigo = venda.Codigo,
                                CodigoCliente = venda.CodigoCliente,
                                Data = venda.Data,
                                Produtos = venda.Produtos,
                                Total = venda.Total
                            }).Include(x => x.Produtos).Where(x => x.Codigo == id).FirstOrDefault();
            return objVenda;
        }

        public override void Delete(int id)
        {
            var listaProdutos = DbSetContext.Include(x => x.Produtos).Where(z => z.Codigo == id).AsNoTracking().ToList();

            VendaProdutos vendaProdutos = new VendaProdutos();
            foreach (var item in listaProdutos[0].Produtos)
            {
                vendaProdutos.CodigoVenda = item.CodigoVenda;
                vendaProdutos.CodigoProduto = item.CodigoProduto;

                dbSetVendaProdutos = Db.Set<VendaProdutos>();
                dbSetVendaProdutos.Attach(vendaProdutos);
                dbSetVendaProdutos.Remove(vendaProdutos);
                Db.SaveChanges();
            }

            base.Delete(id);
        }
    }
}

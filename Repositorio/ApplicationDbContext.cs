using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominio.Entidades;


namespace Repositorio.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        //Usando construtor padrão e sobrescrevendo. Passando o parâmetro específico:
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Reaproveita o que está na classe ModelBuilder
            base.OnModelCreating(builder);
            //Configuração das chaves primárias
            builder.Entity<VendaProdutos>().HasKey(x => new { x.CodigoVenda, x.CodigoProduto });
            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda) //Uma venda com 
                .WithMany(p => p.Produtos) //varios produtos
                .HasForeignKey(x => x.CodigoVenda);

            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto) //Uma venda com 
                .WithMany(p => p.Vendas) //varios produtos
                .HasForeignKey(x => x.CodigoProduto);


        }
    }
}

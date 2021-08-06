namespace LojaBlazor.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Models;

    public class LojaBlazorDbContext : IdentityDbContext<Usuario, Role, string>
    {
        public LojaBlazorDbContext(DbContextOptions<LojaBlazorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<PedidoProdutos> PedidosProdutos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<CarrinhoCompras> CarrinhosCompras { get; set; }

        public DbSet<CarrinhoComprasProdutos> CarrinhoCompraProdutos { get; set; }

        public DbSet<ListaDesejos> ListaDesejos { get; set; }

        public DbSet<ListaDesejosProdutos> ListaDesejosProdutos { get; set; }

        public override int SaveChanges()
        {
            this.AplicarRegrasInformacaoAuditoria();
            this.AplicarRegrasEntidadesDeletaveis();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.AplicarRegrasInformacaoAuditoria();
            this.AplicarRegrasEntidadesDeletaveis();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        private void AplicarRegrasInformacaoAuditoria()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified))
                .ToList()
                .ForEach(entry =>
                {
                    var entity = (IAuditInfo)entry.Entity;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CriadoEm = DateTime.UtcNow;
                    }
                    else
                    {
                        entity.ModificadoEm = DateTime.UtcNow;
                    }
                });

        private void AplicarRegrasEntidadesDeletaveis()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IDeletavelEntity &&
                    e.State == EntityState.Deleted)
                .ToList()
                .ForEach(entry =>
                {
                    var entity = (IDeletavelEntity)entry.Entity;

                    entity.EstaDeletado = true;
                    entity.DeletadoEm = DateTime.UtcNow;
                    entry.State = EntityState.Modified;
                });
    }
}

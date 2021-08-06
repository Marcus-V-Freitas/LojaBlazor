namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class ListaDesejosProdutosConfiguration : IEntityTypeConfiguration<ListaDesejosProdutos>
    {
        public void Configure(EntityTypeBuilder<ListaDesejosProdutos> wishlistProduct)
        {
            wishlistProduct
                .HasKey(wp => new { wp.ListaDesejosId, wp.ProdutoId });

            wishlistProduct
                .HasOne(wp => wp.ListaDesejos)
                .WithMany(w => w.Produtos)
                .HasForeignKey(wp => wp.ListaDesejosId);

            wishlistProduct
                .HasOne(wp => wp.Produto)
                .WithMany(p => p.ListaDesejos)
                .HasForeignKey(wp => wp.ProdutoId);
        }
    }
}

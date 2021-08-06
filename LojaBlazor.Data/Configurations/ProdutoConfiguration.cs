namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstantes.Common;
    using static ModelConstantes.Produto;

    internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> product)
        {
            product
                .Property(p => p.Nome)
                .HasMaxLength(TamanhoMaxNome)
                .IsRequired();

            product
                .Property(p => p.Descricao)
                .HasMaxLength(TamanhoMaxDescricao);

            product
                .Property(p => p.FonteImagem)
                .HasMaxLength(TamanhoMaxUrl)
                .IsRequired();

            product
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");

            product
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            product
                .HasIndex(p => p.EstaDeletado);

            product
                .HasQueryFilter(p => !p.EstaDeletado);
        }
    }
}
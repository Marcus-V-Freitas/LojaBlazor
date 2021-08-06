namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstantes.Common;

    internal class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> category)
        {
            category
                .Property(c => c.Nome)
                .HasMaxLength(TamanhoMaxNome)
                .IsRequired();

            category
                .HasIndex(c => c.EstaDeletado);

            category
                .HasQueryFilter(c => !c.EstaDeletado);
        }
    }
}

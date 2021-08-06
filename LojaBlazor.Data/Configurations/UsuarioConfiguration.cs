namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstantes.Common;

    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> user)
        {
            user
                .Property(u => u.PrimeiroNome)
                .HasMaxLength(TamanhoMaxNome)
                .IsRequired();

            user
                .Property(u => u.Sobrenome)
                .HasMaxLength(TamanhoMaxNome)
                .IsRequired();

            user
                .HasIndex(u => u.EstaDeletado);

            user
                .HasQueryFilter(u => !u.EstaDeletado);
        }
    }
}

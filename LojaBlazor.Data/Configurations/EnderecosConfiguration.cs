namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstantes.Endereco;

    internal class EnderecosConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> address)
        {
            address
                .Property(a => a.Pais)
                .HasMaxLength(TamanhoMaxPais)
                .IsRequired();

            address
                .Property(a => a.Estado)
                .HasMaxLength(TamanhoMaxEstado)
                .IsRequired();

            address
                .Property(a => a.Cidade)
                .HasMaxLength(TamanhoMinCidade)
                .IsRequired();

            address
                .Property(a => a.Descricao)
                .HasMaxLength(TamanhoMaxDescricao)
                .IsRequired();

            address
                .Property(a => a.CodigoPostal)
                .HasMaxLength(TamanhoMaxCodigoPostal)
                .IsRequired();

            address
                .Property(a => a.NumeroTelefone)
                .HasMaxLength(TamanhoMaxNumeroTelefone)
                .IsRequired();

            address
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Enderecos)
                .HasForeignKey(a => a.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            address
                .HasIndex(a => a.EstaDeletado);

            address
                .HasQueryFilter(a => !a.EstaDeletado);
        }
    }
}
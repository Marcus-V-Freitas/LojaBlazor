namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class ListaDesejosConfiguration : IEntityTypeConfiguration<ListaDesejos>
    {
        public void Configure(EntityTypeBuilder<ListaDesejos> wishlist)
            => wishlist
                .HasOne(w => w.Usuarios)
                .WithMany(u => u.ListaDesejos)
                .HasForeignKey(w => w.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
    }
}

namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class CarrinhoComprasConfiguration : IEntityTypeConfiguration<CarrinhoCompras>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompras> shoppingCart)
            => shoppingCart
                .HasOne(sc => sc.Usuario)
                .WithMany(u => u.CarrinhosCompras)
                .HasForeignKey(sc => sc.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
    }
}

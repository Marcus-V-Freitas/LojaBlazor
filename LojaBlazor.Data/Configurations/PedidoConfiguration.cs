namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> order)
        {
            order
                .HasOne(o => o.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(o => o.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            order
                .HasOne(o => o.EnderecoEntrega)
                .WithMany(a => a.Pedidos)
                .HasForeignKey(o => o.EnderecoEntregaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
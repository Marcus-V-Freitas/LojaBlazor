namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class PedidoProdutosConfiguration : IEntityTypeConfiguration<PedidoProdutos>
    {
        public void Configure(EntityTypeBuilder<PedidoProdutos> orderProduct)
        {
            orderProduct
                .HasKey(op => new { op.PedidoId, op.ProdutoId });

            orderProduct
                .HasOne(op => op.Pedido)
                .WithMany(o => o.Produtos)
                .HasForeignKey(o => o.PedidoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            orderProduct
                .HasOne(op => op.Produto)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(o => o.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

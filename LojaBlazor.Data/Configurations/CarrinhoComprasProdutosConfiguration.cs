namespace LojaBlazor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class CarrinhoComprasProdutosConfiguration : IEntityTypeConfiguration<CarrinhoComprasProdutos>
    {
        public void Configure(EntityTypeBuilder<CarrinhoComprasProdutos> shoppingCart)
        {
            shoppingCart
                .HasKey(sc => new { sc.CarrinhoComprasId, sc.ProdutoId });

            shoppingCart
                .HasOne(sc => sc.CarrinhoCompras)
                .WithMany(u => u.Produtos)
                .HasForeignKey(sc => sc.CarrinhoComprasId);

            shoppingCart
                .HasOne(sc => sc.Produto)
                .WithMany(p => p.CarrinhosCompras)
                .HasForeignKey(sc => sc.ProdutoId);
        }
    }
}

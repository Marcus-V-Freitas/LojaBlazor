namespace LojaBlazor.Services.Pedidos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using LojaBlazor.Models.Pedidos;

    public class PedidosService : BaseService<Pedido>, IPedidosService
    {
        public PedidosService(LojaBlazorDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<string> CompraAsync(
            PedidosRequestModel model, string userId)
        {
            var order = new Pedido
            {
                UsuarioId = userId,
                EnderecoEntregaId = model.EnderecoId
            };

            var shoppingCartProducts = await this
                .Data
                .CarrinhoCompraProdutos
                .Where(sc => sc.CarrinhoCompras.UsuarioId == userId)
                .ToListAsync();

            var orderProducts = new List<PedidoProdutos>();

            foreach (var shoppingCartProduct in shoppingCartProducts)
            {
                var productId = shoppingCartProduct.ProdutoId;
                var requestQuantity = shoppingCartProduct.Quantidade;

                var orderProduct = new PedidoProdutos
                {
                    Pedido = order,
                    ProdutoId = productId,
                    Quantidade = requestQuantity
                };

                orderProducts.Add(orderProduct);

                await this.ReduceProductQuantity(productId, requestQuantity);
            }

            this.Data.RemoveRange(shoppingCartProducts);

            await this.Data.AddRangeAsync(orderProducts);
            await this.Data.SaveChangesAsync();

            return order.Id;
        }

        public async Task<PedidosDetalhesResponseModel> DetalhesAsync(
            string id)
            => await this.Mapper
                .ProjectTo<PedidosDetalhesResponseModel>(this
                    .TodosAsNoTracking()
                    .Where(o => o.Id == id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<PedidosListagemResponseModel>> UsuarioPorIdAsync(
            string userId)
            => await this.Mapper
                .ProjectTo<PedidosListagemResponseModel>(this
                    .TodosAsNoTracking()
                    .Where(o => o.UsuarioId == userId)
                    .SelectMany(o => o.Produtos))
                .ToListAsync();

        private async Task ReduceProductQuantity(
            int productId,
            int requestQuantity)
        {
            var product = await this
                .Data
                .Produtos
                .FindAsync(productId);

            product.Quantidade -= requestQuantity;
        }
    }
}

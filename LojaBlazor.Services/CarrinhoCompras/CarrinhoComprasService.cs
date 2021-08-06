namespace LojaBlazor.Services.ShoppingCarts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using Models.CarrinhoCompras;

    public class CarrinhoComprasService : BaseService<CarrinhoCompras>, ICarrinhoComprasService
    {
        private const string InvalidErrorMessage = "Este usuário não pode editar este carrinho de compras.";
        private const string NotEnoughProductsMessage = "Não há produtos suficientes em estoque.";

        public CarrinhoComprasService(LojaBlazorDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<Resultado> AddProductAsync(
            CarrinhoComprasRequestModel model, string userId)
        {
            var productId = model.ProductId;
            var requestQuantity = model.Quantidade;

            var productQuantity = await this.GetProductQuantityById(productId);

            if (productQuantity < requestQuantity)
            {
                return NotEnoughProductsMessage;
            }

            var shoppingCart = await this
                .Todos()
                .FirstOrDefaultAsync(c => c.UsuarioId == userId);

            shoppingCart ??= new CarrinhoCompras
            {
                UsuarioId = userId
            };

            var shoppingCartProduct = new CarrinhoComprasProdutos
            {
                CarrinhoCompras = shoppingCart,
                ProdutoId = productId,
                Quantidade = requestQuantity
            };

            await this.Data.AddAsync(shoppingCartProduct);
            await this.Data.SaveChangesAsync();

            return Resultado.Success;
        }

        public async Task<Resultado> UpdateProductAsync(
            CarrinhoComprasRequestModel model, string userId)
        {
            var productId = model.ProductId;
            var requestQuantity = model.Quantidade;

            var productQuantity = await this.GetProductQuantityById(productId);

            if (productQuantity < requestQuantity)
            {
                return NotEnoughProductsMessage;
            }

            var shoppingCartProduct = await this.FindByProductAndUserAsync(
                productId,
                userId);

            if (shoppingCartProduct == null)
            {
                return InvalidErrorMessage;
            }

            shoppingCartProduct.Quantidade = requestQuantity;

            await this.Data.SaveChangesAsync();

            return Resultado.Success;
        }

        public async Task<Resultado> RemoveProductAsync(
            int productId, string userId)
        {
            var shoppingCartProduct = await this.FindByProductAndUserAsync(
                productId,
                userId);

            if (shoppingCartProduct == null)
            {
                return InvalidErrorMessage;
            }

            this.Data.Remove(shoppingCartProduct);

            await this.Data.SaveChangesAsync();

            return Resultado.Success;
        }

        public async Task<int> TotalAsync(
            string userId)
            => await this
                .AllByUserId(userId)
                .CountAsync();

        public async Task<IEnumerable<CarrinhoComprasProdutoResponseModel>> ByUserAsync(
            string userId)
            => await this.Mapper
                .ProjectTo<CarrinhoComprasProdutoResponseModel>(this
                    .AllByUserId(userId)
                    .AsNoTracking())
                .ToListAsync();

        private async Task<CarrinhoComprasProdutos> FindByProductAndUserAsync(
            int productId,
            string userId)
            => await this
                .AllByUserId(userId)
                .FirstOrDefaultAsync(c => c.ProdutoId == productId);

        private IQueryable<CarrinhoComprasProdutos> AllByUserId(
            string userId)
            => this
                .Todos()
                .Where(c => c.UsuarioId == userId)
                .SelectMany(c => c.Produtos);

        private async Task<int> GetProductQuantityById(
            int productId)
            => await this
                .Data
                .Produtos
                .Where(p => p.Id == productId)
                .Select(p => p.Quantidade)
                .FirstOrDefaultAsync();
    }
}

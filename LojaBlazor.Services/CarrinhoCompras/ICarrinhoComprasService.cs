namespace LojaBlazor.Services.ShoppingCarts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.CarrinhoCompras;

    public interface ICarrinhoComprasService : IService
    {
        Task<Resultado> AddProductAsync(CarrinhoComprasRequestModel model, string userId);

        Task<Resultado> UpdateProductAsync(CarrinhoComprasRequestModel model, string userId);

        Task<Resultado> RemoveProductAsync(int productId, string userId);

        Task<int> TotalAsync(string userId);

        Task<IEnumerable<CarrinhoComprasProdutoResponseModel>> ByUserAsync(string userId);
    }
}

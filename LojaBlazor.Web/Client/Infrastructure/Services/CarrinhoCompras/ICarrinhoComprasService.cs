namespace LojaBlazor.Web.Client.Infrastructure.Services.CarrinhoCompras
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;
    using Models.CarrinhoCompras;

    public interface ICarrinhoComprasService
    {
        Task<Resultado> AdicionarProduto(CarrinhoComprasRequestModel model);

        Task<Resultado> EditarProduto(CarrinhoComprasRequestModel model);

        Task<Resultado> ExcluirProduto(int id);

        Task<int> TotalProdutos();

        Task<IEnumerable<CarrinhoComprasProdutoResponseModel>> Meu();
    }
}

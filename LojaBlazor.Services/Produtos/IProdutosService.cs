namespace LojaBlazor.Services.Produtos
{
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.Produtos;

    public interface IProdutosService : IService
    {
        Task<int> CreateAsync(ProdutosRequestModel model);

        Task<Resultado> UpdateAsync(int id, ProdutosRequestModel model);

        Task<Resultado> DeleteAsync(int id);

        Task<ProdutosDetalhesResponseModel> DetailsAsync(int id);

        Task<ProdutosBuscaResponseModel> SearchAsync(ProdutosBuscaRequestModel model);
    }
}
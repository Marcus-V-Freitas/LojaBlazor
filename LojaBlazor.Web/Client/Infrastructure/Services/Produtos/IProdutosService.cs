namespace LojaBlazor.Web.Client.Infrastructure.Services.Produtos
{
    using System.Threading.Tasks;

    using Models;
    using Models.Produtos;

    public interface IProdutosService
    {
        Task<int> CriarAsync(ProdutosRequestModel model);

        Task<Resultado> EditarAsync(int id, ProdutosRequestModel model);

        Task<Resultado> ExcluirAsync(int id);

        Task<TModel> DetalhesAsync<TModel>(int id) 
            where TModel : class;

        Task<ProdutosBuscaResponseModel> BuscarAsync(ProdutosBuscaRequestModel model);
    }
}
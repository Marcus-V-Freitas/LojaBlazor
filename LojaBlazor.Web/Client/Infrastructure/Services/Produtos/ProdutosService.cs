namespace LojaBlazor.Web.Client.Infrastructure.Services.Produtos
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Extensions;
    using Models;
    using Models.Produtos;

    public class ProdutosService : IProdutosService
    {
        private readonly HttpClient http;

        private const string CaminhoProdutos = "api/produtos";
        private const string CaminhoProdutosBarra = CaminhoProdutos + "/";
        private const string CaminhoProdutosBusca = CaminhoProdutos + "?category={0}&minPrice={1}&maxPrice={2}&query={3}&page={4}";

        public ProdutosService(HttpClient http) => this.http = http;

        public async Task<int> CriarAsync(
            ProdutosRequestModel model)
        {
            var resposta = await this.http.PostAsJsonAsync(CaminhoProdutos, model);
            var id = await resposta.Content.ReadFromJsonAsync<int>();
            return id;
        }

        public async Task<Resultado> EditarAsync(
            int id, ProdutosRequestModel model)
            => await this.http
                .PutAsJsonAsync(CaminhoProdutosBarra + id, model)
                .ToResult();

        public async Task<Resultado> ExcluirAsync(
            int id)
            => await this.http
                .DeleteAsync(CaminhoProdutosBarra + id)
                .ToResult();

        public async Task<TModel> DetalhesAsync<TModel>(
            int id)
            where TModel : class
            => await this.http.GetFromJsonAsync<TModel>(CaminhoProdutosBarra + id);

        public async Task<ProdutosBuscaResponseModel> BuscarAsync(
            ProdutosBuscaRequestModel model)
            => await this.http.GetFromJsonAsync<ProdutosBuscaResponseModel>(
                string.Format(
                    CaminhoProdutosBusca,
                    model.Categoria,
                    model.PrecoMin,
                    model.PrecoMax,
                    model.Query,
                    model.Pagina));
    }
}
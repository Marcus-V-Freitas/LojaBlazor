namespace LojaBlazor.Web.Client.Infrastructure.Services.CarrinhoCompras
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Extensions;
    using Models;
    using Models.CarrinhoCompras;

    public class CarrinhoComprasService : ICarrinhoComprasService
    {
        private readonly HttpClient http;

        private const string CaminhoCarrinhoCompras = "api/carrinhocompras";

        public CarrinhoComprasService(HttpClient http) => this.http = http;

        public async Task<Resultado> AdicionarProduto(CarrinhoComprasRequestModel model)
            => await this.http
                .PostAsJsonAsync($"{CaminhoCarrinhoCompras}/adicionarproduto", model)
                .ToResult();

        public async Task<Resultado> EditarProduto(CarrinhoComprasRequestModel model)
            => await this.http
                .PutAsJsonAsync($"{CaminhoCarrinhoCompras}/{nameof(this.EditarProduto)}", model)
                .ToResult();

        public async Task<Resultado> ExcluirProduto(int id)
            => await this.http.DeleteAsync($"{CaminhoCarrinhoCompras}/{nameof(this.ExcluirProduto)}/{id}").ToResult();

        public async Task<int> TotalProdutos()
            => await this.http.GetFromJsonAsync<int>($"{CaminhoCarrinhoCompras}/{nameof(this.TotalProdutos)}");

        public async Task<IEnumerable<CarrinhoComprasProdutoResponseModel>> Meu()
            => await this.http.GetFromJsonAsync<IEnumerable<CarrinhoComprasProdutoResponseModel>>(CaminhoCarrinhoCompras);
    }
}

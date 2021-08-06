namespace LojaBlazor.Web.Client.Infrastructure.Services.ListaDesejos
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Extensions;
    using Models;
    using Models.ListaDesejos;

    public class ListaDesejosService : IListaDesejosService
    {
        private readonly HttpClient http;

        private const string CaminhoListaDesejos = "api/listadesejos";

        public ListaDesejosService(HttpClient http) => this.http = http;

        public async Task<Resultado> AdicionarProduto(int id)
            => await this.http
                .PostAsJsonAsync($"{CaminhoListaDesejos}/{nameof(this.AdicionarProduto)}/{id}", id)
                .ToResult();

        public async Task<Resultado> ExcluirProduto(int id)
            => await this.http
                .DeleteAsync($"{CaminhoListaDesejos}/{nameof(this.ExcluirProduto)}/{id}")
                .ToResult();

        public async Task<IEnumerable<ListaDesejosProdutosResponseModel>> Meu()
            => await this.http.GetFromJsonAsync<IEnumerable<ListaDesejosProdutosResponseModel>>(CaminhoListaDesejos);
    }
}

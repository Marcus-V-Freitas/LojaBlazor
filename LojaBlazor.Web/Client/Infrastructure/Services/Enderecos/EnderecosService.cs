namespace LojaBlazor.Web.Client.Infrastructure.Services.Enderecos
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Extensions;
    using Models;
    using Models.Enderecos;

    public class EnderecosService : IEnderecosService
    {
        private readonly HttpClient http;

        private const string CaminhoEndereco = "api/enderecos";
        private const string CaminhoEnderecoBarra = CaminhoEndereco + "/";

        public EnderecosService(HttpClient http) => this.http = http;

        public async Task<int> CriarAsync(EnderecoRequestModel model)
        {
            var addressResponse = await this.http.PostAsJsonAsync(CaminhoEndereco, model);
            var addressId = await addressResponse.Content.ReadFromJsonAsync<int>();

            return addressId;
        }

        public async Task<Resultado> ExcluirAsync(int id)
            => await this.http
                .DeleteAsync(CaminhoEnderecoBarra + id)
                .ToResult();

        public async Task<IEnumerable<EnderecoListagemResponseModel>> Meu()
            => await this.http.GetFromJsonAsync<IEnumerable<EnderecoListagemResponseModel>>(CaminhoEndereco);
    }
}

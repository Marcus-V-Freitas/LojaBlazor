namespace LojaBlazor.Web.Client.Infrastructure.Services.Pedidos
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using LojaBlazor.Models.Pedidos;

    public class PedidosService : IPedidosService
    {
        private readonly HttpClient http;

        private const string CaminhoPedidos = "api/pedidos";
        private const string CaminhosPedidoBarra = CaminhoPedidos + "/";

        public PedidosService(HttpClient http) => this.http = http;

        public async Task<string> Compra(PedidosRequestModel model)
        {
            var pedidoResposta = await this.http.PostAsJsonAsync(CaminhoPedidos, model);
            var pedidoId = await pedidoResposta.Content.ReadAsStringAsync();

            return pedidoId;
        }

        public async Task<PedidosDetalhesResponseModel> Detalhes(string id)
            => await this.http.GetFromJsonAsync<PedidosDetalhesResponseModel>(CaminhosPedidoBarra + id);

        public async Task<IEnumerable<PedidosListagemResponseModel>> Meu()
            => await this.http.GetFromJsonAsync<IEnumerable<PedidosListagemResponseModel>>(CaminhoPedidos);
    }
}

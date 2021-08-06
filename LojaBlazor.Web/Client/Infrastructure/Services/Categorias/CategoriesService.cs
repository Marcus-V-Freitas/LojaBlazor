namespace LojaBlazor.Web.Client.Infrastructure.Services.Categorias
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Models.Categorias;

    public class CategoriesService : ICategoriasService
    {
        private readonly HttpClient http;

        private const string CaminhoCategorias = "api/categorias";

        public CategoriesService(HttpClient http) => this.http = http;

        public async Task<IEnumerable<CategoriaListagemResponseModel>> Todos()
            => await this.http.GetFromJsonAsync<IEnumerable<CategoriaListagemResponseModel>>(CaminhoCategorias);
    }
}

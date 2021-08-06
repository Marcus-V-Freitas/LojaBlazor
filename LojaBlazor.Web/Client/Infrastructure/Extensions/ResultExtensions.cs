namespace LojaBlazor.Web.Client.Infrastructure.Extensions
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Models;

    public static class ResultExtensions
    {
        public static async Task<Resultado> ToResult(this Task<HttpResponseMessage> responseTask)
        {
            var response = await responseTask;

            if (!response.IsSuccessStatusCode)
            {
                var errors = await response.Content.ReadFromJsonAsync<string[]>();

                return Resultado.Failure(errors);
            }

            return Resultado.Success;
        }
    }
}

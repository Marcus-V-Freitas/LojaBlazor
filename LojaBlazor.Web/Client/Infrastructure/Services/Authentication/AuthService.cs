namespace LojaBlazor.Web.Client.Infrastructure.Services.Authentication
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;

    using Extensions;
    using Infrastructure;
    using Models;
    using Models.Identity;

    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        private const string CaminhoLogin = "api/identity/login";
        private const string CaminhoRegistrar = "api/identity/registrar";

        public AuthService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Resultado> Registrar(RegistrarRequestModel model)
            => await this.httpClient
                .PostAsJsonAsync(CaminhoRegistrar, model)
                .ToResult();

        public async Task<Resultado> Login(LoginRequestModel model)
        {
            var respostas = await this.httpClient.PostAsJsonAsync(CaminhoLogin, model);

            if (!respostas.IsSuccessStatusCode)
            {
                var erros = await respostas.Content.ReadFromJsonAsync<string[]>();

                return Resultado.Failure(erros);
            }

            var responseAsString = await respostas.Content.ReadAsStringAsync();

            var responseObject = JsonSerializer.Deserialize<LoginResponseModel>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var token = responseObject.Token;

            await this.localStorage.SetItemAsync("authToken", token);

            ((ApiAuthenticationStateProvider)this.authenticationStateProvider).MarcarUsuarioComoAutenticado(model.Email);

            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return Resultado.Success;
        }

        public async Task Logout()
        {
            await this.localStorage.RemoveItemAsync("authToken");

            ((ApiAuthenticationStateProvider)this.authenticationStateProvider).MarcarUsuarioComoConectado();

            this.httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}

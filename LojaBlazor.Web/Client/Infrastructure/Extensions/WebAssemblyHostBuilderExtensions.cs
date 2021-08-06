namespace LojaBlazor.Web.Client.Infrastructure.Extensions
{
    using System;
    using System.Net.Http;

    using Blazored.LocalStorage;
    using Blazored.Toast;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using Services.Enderecos;
    using Services.Authentication;
    using Services.Categorias;
    using Services.Pedidos;
    using Services.Produtos;
    using Services.CarrinhoCompras;
    using Services.ListaDesejos;

    public static class WebAssemblyHostBuilderExtensions
    {
        private const string ClientName = "LojaBlazor.ServerAPI";

        public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("app");

            return builder;
        }

        public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
        {
            builder
                .Services
                .AddAuthorizationCore()
                .AddBlazoredToast()
                .AddBlazoredLocalStorage()
                .AddScoped<ApiAuthenticationStateProvider>()
                .AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>()
                .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(ClientName))
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IEnderecosService, EnderecosService>()
                .AddTransient<ICategoriasService, CategoriesService>()
                .AddTransient<IPedidosService, PedidosService>()
                .AddTransient<IProdutosService, ProdutosService>()
                .AddTransient<ICarrinhoComprasService, CarrinhoComprasService>()
                .AddTransient<IListaDesejosService, ListaDesejosService>()
                .AddTransient<AuthenticationHeaderHandler>()
                .AddHttpClient(
                    ClientName,
                    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

            return builder;
        }
    }
}

namespace LojaBlazor.Web.Client.Pages.Conta
{
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Infrastructure.Extensions;
    using Models.Identity;

    public partial class Configuracao
    {
        private readonly TrocarConfiguracoesRequestModel Model = new TrocarConfiguracoesRequestModel();

        private string Email;

        public bool MostrarErros { get; set; }

        public IEnumerable<string> Erros { get; set; }

        protected override async Task OnInitializedAsync() => await this.CarregarDadosAsync();

        private async Task GravarAsync()
        {
            var resposta = await this.Http.PutAsJsonAsync("api/identity/mudarconfiguracoes", this.Model);

            if (resposta.IsSuccessStatusCode)
            {
                this.MostrarErros = false;

                await this.AuthService.Logout();

                this.ToastService.ShowSuccess("As configurações da sua conta foram alteradas com sucesso.\n Por favor, faça o login.");
                this.NavigationManager.NavigateTo("/conta/login");
            }
            else
            {
                this.Erros = await resposta.Content.ReadFromJsonAsync<string[]>();
                this.MostrarErros = true;
            }
        }

        private async Task CarregarDadosAsync()
        {
            var state = await this.AuthState.GetAuthenticationStateAsync();
            var user = state.User;

            this.Email = user.GetEmail();
            this.Model.PrimeiroNome = user.GetFirstName();
            this.Model.Sobrenome = user.GetLastName();
        }
    }
}

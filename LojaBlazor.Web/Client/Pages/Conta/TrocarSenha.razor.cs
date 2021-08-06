namespace LojaBlazor.Web.Client.Pages.Conta
{
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Models.Identity;

    public partial class TrocarSenha
    {
        private readonly TrocarSenhaRequestModel Model = new TrocarSenhaRequestModel();

        public bool MostrarErros { get; set; }

        public IEnumerable<string> Erros { get; set; }

        private async Task GravarAsync()
        {
            var resposta = await this.Http.PutAsJsonAsync("api/identity/mudarsenha", this.Model);

            if (resposta.IsSuccessStatusCode)
            {
                this.MostrarErros = false;

                this.Model.Senha = null;
                this.Model.SenhaNova = null;
                this.Model.ConfirmarSenhaNova = null;

                await this.AuthService.Logout();

                this.ToastService.ShowSuccess("Sua senha foi alterada com sucesso.\n Por favor, faça o login.");
                this.NavigationManager.NavigateTo("/conta/login");
            }
            else
            {
                this.Erros = await resposta.Content.ReadFromJsonAsync<string[]>();
                this.MostrarErros = true;
            }
        }
    }
}

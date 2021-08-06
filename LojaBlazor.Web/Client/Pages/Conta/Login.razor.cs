namespace LojaBlazor.Web.Client.Pages.Conta
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Identity;

    public partial class Login
    {
        private readonly LoginRequestModel model = new LoginRequestModel();

        public bool MostrarErros { get; set; }

        public IEnumerable<string> Erros { get; set; }

        private async Task GravarAsync()
        {
            var resultado = await this.AuthService.Login(this.model);

            if (resultado.Sucesso)
            {
                this.MostrarErros = false;
                this.ToastService.ShowSuccess("Você fez login com sucesso!");
                this.NavigationManager.NavigateTo("/");
            }
            else
            {
                this.Erros = resultado.Erros;
                this.MostrarErros = true;
            }
        }
    }
}

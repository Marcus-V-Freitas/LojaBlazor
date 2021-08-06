namespace LojaBlazor.Web.Client.Pages.Conta
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Identity;

    public partial class Registrar
    {
        private readonly RegistrarRequestModel Model = new RegistrarRequestModel();

        public bool MostrarErros { get; set; }

        public IEnumerable<string> Erros { get; set; }

        private async Task GravarAsync()
        {
            var resultado = await this.AuthService.Registrar(this.Model);

            if (resultado.Sucesso)
            {
                this.MostrarErros = false;
                this.ToastService.ShowSuccess(
                    "Você se registrou com sucesso.\n Por favor, faça o login",
                    "Parabéns!");
                this.NavigationManager.NavigateTo("/conta/login");
            }
            else
            {
                this.Erros = resultado.Erros;
                this.MostrarErros = true;
            }
        }
    }
}

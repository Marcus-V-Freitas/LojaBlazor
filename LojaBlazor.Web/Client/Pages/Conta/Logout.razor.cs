namespace LojaBlazor.Web.Client.Pages.Conta
{
    using System.Threading.Tasks;

    public partial class Logout
    {
        private async Task Sair()
        {
            this.ToastService.ShowSuccess("Você se desconectou com sucesso.");
            await this.AuthService.Logout();
        }
    }
}

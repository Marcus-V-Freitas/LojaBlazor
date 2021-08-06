namespace LojaBlazor.Web.Client.Shared
{
    using System.Threading.Tasks;

    public partial class BarraLateral
    {
        private async Task Logout()
        {
            this.ToastService.ShowSuccess("Você se desconectou com sucesso!");
            await this.AuthService.Logout();
        }
    }
}

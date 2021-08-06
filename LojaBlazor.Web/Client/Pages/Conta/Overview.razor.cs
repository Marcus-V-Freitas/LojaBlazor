namespace LojaBlazor.Web.Client.Pages.Conta
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LojaBlazor.Models.Pedidos;
    using Infrastructure.Extensions;

    public partial class Overview
    {
        private IEnumerable<PedidosListagemResponseModel> Pedidos;

        private string Email;
        private string PrimeiroNome;
        private string Sobrenome;

        protected override async Task OnInitializedAsync() => await this.CarregarDadosAsync();

        private async Task CarregarDadosAsync()
        {
            var state = await this.AuthState.GetAuthenticationStateAsync();
            var user = state.User;

            this.Email = user.GetEmail();
            this.PrimeiroNome = user.GetFirstName();
            this.Sobrenome = user.GetLastName();

            this.Pedidos = await this.PedidosService.Meu();
            this.Pedidos = this.Pedidos.Take(4);
        }
    }
}

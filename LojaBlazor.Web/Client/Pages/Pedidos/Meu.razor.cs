namespace LojaBlazor.Web.Client.Pages.Pedidos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LojaBlazor.Models.Pedidos;

    public partial class Meu
    {
        private IEnumerable<PedidosListagemResponseModel> Pedidos;

        protected override async Task OnInitializedAsync()
            => this.Pedidos = await this.PedidosService.Meu();
    }
}

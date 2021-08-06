namespace LojaBlazor.Web.Client.Pages.Pedidos
{
    using System.Linq;
    using System.Threading.Tasks;
    using LojaBlazor.Models.Pedidos;
    using Microsoft.AspNetCore.Components;

    public partial class Detalhes
    {
        private PedidosDetalhesResponseModel Pedido;
        private decimal TotalPreco;

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Pedido = await this.PedidosService.Detalhes(this.Id);
            this.TotalPreco = this.Pedido.Produtos.Sum(p => p.Preco * p.Quantidade);
        }
    }
}

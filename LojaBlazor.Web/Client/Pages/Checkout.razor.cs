namespace LojaBlazor.Web.Client.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LojaBlazor.Models.Pedidos;
    using Infrastructure.Extensions;
    using Models.Enderecos;
    using Models.CarrinhoCompras;

    public partial class Checkout
    {
        private readonly EnderecoRequestModel Endereco = new EnderecoRequestModel();
        private readonly PedidosRequestModel Pedido = new PedidosRequestModel();

        private string Email;
        private decimal PrecoTotal;
        private IEnumerable<CarrinhoComprasProdutoResponseModel> ProdutosCarrinho;

        protected override async Task OnInitializedAsync()
        {
            var state = await this.AuthState.GetAuthenticationStateAsync();
            var user = state.User;

            this.Email = user.GetEmail();

            this.ProdutosCarrinho = await this.CarrinhoComprasService.Meu();
            this.PrecoTotal = this.ProdutosCarrinho.Sum(p => p.Preco * p.Quantidade);
        }

        private async Task GravarAsync()
        {
            var enderecoId = await this.EnderecosService.CriarAsync(this.Endereco);
            this.Pedido.EnderecoId = enderecoId;
            var orderId = await this.PedidosService.Compra(this.Pedido);
            this.NavigationManager.NavigateTo($"/pedido/confirmado/{orderId}", forceLoad: true);
        }
    }
}

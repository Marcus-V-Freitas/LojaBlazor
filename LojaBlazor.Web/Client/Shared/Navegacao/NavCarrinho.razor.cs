namespace LojaBlazor.Web.Client.Shared.Navegacao
{
    using System.Threading.Tasks;

    public partial class NavCarrinho
    {
        private int? ProdutosCarrinhoCount;

        protected override async Task OnInitializedAsync()
            => this.ProdutosCarrinhoCount = await this.CarrinhoComprasService.TotalProdutos();
    }
}

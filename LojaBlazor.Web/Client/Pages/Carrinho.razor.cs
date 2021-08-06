namespace LojaBlazor.Web.Client.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models.CarrinhoCompras;

    public partial class Carrinho
    {
        private readonly CarrinhoComprasRequestModel Model = new CarrinhoComprasRequestModel();

        private decimal PrecoTotal;
        private IEnumerable<CarrinhoComprasProdutoResponseModel> ProdutosCarrinho;

        protected override async Task OnInitializedAsync() => await this.CarregarDadosAsync();

        private async Task CarregarDadosAsync()
        {
            this.ProdutosCarrinho = await this.CarrinhoComprasService.Meu();
            this.PrecoTotal = this.ProdutosCarrinho.Sum(p => p.Preco * p.Quantidade);
        }

        private async Task ExcluirAsync(int productId)
        {
            await this.CarrinhoComprasService.ExcluirProduto(productId);
            this.NavigationManager.NavigateTo("/carrinho", forceLoad: true);
        }

        private async Task IncrementarQuantidade(int id, int quantidade, int quantidadeEstoque)
        {
            this.Model.ProductId = id;
            this.Model.Quantidade = quantidade;

            if (this.Model.Quantidade + 1 <= quantidadeEstoque)
            {
                this.Model.Quantidade++;
                await this.CarrinhoComprasService.EditarProduto(this.Model);
                await this.CarregarDadosAsync();
            }
        }

        private async Task DecrementarQuantidade(int id, int quantidade)
        {
            this.Model.ProductId = id;
            this.Model.Quantidade = quantidade;

            if (this.Model.Quantidade - 1 > 0)
            {
                this.Model.Quantidade--;
                await this.CarrinhoComprasService.EditarProduto(this.Model);
                await this.CarregarDadosAsync();
            }
        }
    }
}

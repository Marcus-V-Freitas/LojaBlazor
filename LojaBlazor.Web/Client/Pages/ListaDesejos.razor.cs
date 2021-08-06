namespace LojaBlazor.Web.Client.Pages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.CarrinhoCompras;
    using Models.ListaDesejos;

    public partial class ListaDesejos
    {
        private IEnumerable<ListaDesejosProdutosResponseModel> Produtos;

        protected override async Task OnInitializedAsync() => await this.CarregarDadosAsync();

        private async Task CarregarDadosAsync() => this.Produtos = await this.ListaDesejosService.Meu();

        private async Task AdicionarAsync(int id)
        {
            var requisicaoCarrinho = new CarrinhoComprasRequestModel
            {
                ProductId = id,
                Quantidade = 1
            };

            await this.CarrinhoComprasService.AdicionarProduto(requisicaoCarrinho);

            this.NavigationManager.NavigateTo("/carrinho", forceLoad: true);
        }

        private async Task RemoverAsync(int id)
        {
            var resultado = await this.ListaDesejosService.ExcluirProduto(id);

            if (resultado.Sucesso)
            {
                await this.CarregarDadosAsync();
            }
        }
    }
}

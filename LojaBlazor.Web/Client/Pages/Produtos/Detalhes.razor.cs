namespace LojaBlazor.Web.Client.Pages.Produtos
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    using Models.Produtos;

    public partial class Detalhes
    {
        private ProdutosDetalhesResponseModel Produto;

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string NomeProduto { get; set; }

        protected override async Task OnInitializedAsync()
            => this.Produto = await this.ProdutosService.DetalhesAsync<ProdutosDetalhesResponseModel>(this.Id);
    }
}

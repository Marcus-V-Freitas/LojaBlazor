namespace LojaBlazor.Web.Client.Pages.Produtos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Categorias;
    using Models.Produtos;

    public partial class Adicionar
    {
        private readonly ProdutosRequestModel Model = new ProdutosRequestModel();

        private IEnumerable<CategoriaListagemResponseModel> Categorias;

        protected override async Task OnInitializedAsync()
            => this.Categorias = await this.CategoriasService.Todos();

        private async Task GravarAsync()
        {
            var id = await this.ProdutosService.CriarAsync(this.Model);
            this.NavigationManager.NavigateTo($"/produtos/{id}/{this.Model.Nome}");
        }
    }
}

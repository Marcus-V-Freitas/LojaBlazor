namespace LojaBlazor.Web.Client.Pages.Produtos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    using Models.Categorias;
    using Models.Produtos;

    public partial class Editar
    {
        private ProdutosRequestModel Model;
        private IEnumerable<CategoriaListagemResponseModel> Categorias;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Model = await this.ProdutosService.DetalhesAsync<ProdutosRequestModel>(this.Id);
            this.Categorias = await this.CategoriasService.Todos();
        }

        private async Task GravarAsync()
        {
            var result = await this.ProdutosService.EditarAsync(this.Id, this.Model);

            if (result.Sucesso)
            {
                this.NavigationManager.NavigateTo($"/produtos/{this.Id}/{this.Model.Nome}");
            }
        }
    }
}

namespace LojaBlazor.Web.Client.Shared.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Categorias;

    public partial class Header
    {
        private IEnumerable<CategoriaListagemResponseModel> Categorias;

        protected override async Task OnInitializedAsync()
            => this.Categorias = await this.CategoriasService.Todos();
    }
}

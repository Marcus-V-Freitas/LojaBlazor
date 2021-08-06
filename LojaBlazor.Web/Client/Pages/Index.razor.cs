namespace LojaBlazor.Web.Client.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Models.Produtos;

    public partial class Index
    {
        private IEnumerable<ProdutoListagemResponseModel> Produtos;

        protected override async Task OnInitializedAsync()
        {
            var response = await Http.GetFromJsonAsync<ProdutosBuscaResponseModel>("api/produtos");
            Produtos = response.Produtos;
        }
    }
}

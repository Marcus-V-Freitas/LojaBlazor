namespace LojaBlazor.Web.Client.Shared.Navegacao
{
    using Models.Produtos;

    public partial class NavMovelMobile
    {
        private readonly ProdutosBuscaRequestModel ModeloBusca = new ProdutosBuscaRequestModel();

        private void Buscar()
            => this.NavigationManager.NavigateTo($"/produtos/procurar/{this.ModeloBusca.Query}/pagina/1");
    }
}

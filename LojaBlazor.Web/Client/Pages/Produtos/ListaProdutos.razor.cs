namespace LojaBlazor.Web.Client.Pages.Produtos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    using Models.Categorias;
    using Models.Produtos;
    using Models.CarrinhoCompras;

    public partial class ListaProdutos
    {
        private readonly ProdutosBuscaRequestModel model = new ProdutosBuscaRequestModel();

        private ProdutosBuscaResponseModel searchResponse;
        private IEnumerable<ProdutoListagemResponseModel> Produtos;
        private IEnumerable<CategoriaListagemResponseModel> Categorias;

        [Parameter]
        public int? IdCategoria { get; set; }

        [Parameter]
        public string NomeCategoria { get; set; }

        [Parameter]
        public string QueryBusca { get; set; } = string.Empty;

        [Parameter]
        public int Pagina { get; set; } = 1;

        [Parameter]
        public bool ListView { get; set; } = false;

        [Parameter]
        public bool GridView { get; set; } = true;

        protected override async Task OnInitializedAsync() => await this.CarregarDados();

        protected override async Task OnParametersSetAsync() => await this.CarregarDados(comCategorias: false);

        private async Task PaginaSelecionada(int pagina)
        {
            Pagina = pagina;
            await this.CarregarDados(comCategorias: false);
        }

        private async Task CarregarDados(bool comCategorias = true)
        {
            if (this.Pagina == 0)
            {
                this.Pagina = 1;
            }

            this.model.Categoria = this.IdCategoria;
            this.model.Query = this.QueryBusca;
            this.model.Pagina = this.Pagina;

            this.searchResponse = await this.ProdutosService.BuscarAsync(this.model);
            this.Produtos = this.searchResponse.Produtos;

            if (comCategorias)
            {
                this.Categorias = await this.CategoriasService.Todos();
            }

            this.Filtrar();
        }

        private async Task AdicionarListaDesejos(int id)
        {
            await this.ListaDesejosService.AdicionarProduto(id);
            this.NavigationManager.NavigateTo("/lista-desejos");
        }

        private async Task AdicionarCarrinho(int id)
        {
            var cartRequest = new CarrinhoComprasRequestModel
            {
                ProductId = id,
                Quantidade = 1
            };

            var result = await this.CarrinhoComprasService.AdicionarProduto(cartRequest);

            if (!result.Sucesso)
            {
                this.ToastService.ShowError(result.Erros.First());
            }
            else
            {
                this.NavigationManager.NavigateTo("/carrinho", forceLoad: true);
            }
        }

        private void MudarVisualizacao()
        {
            this.ListView = !this.ListView;
            this.GridView = !this.GridView;
        }

        private void Redefinir()
        {
            this.model.PrecoMin = null;
            this.model.PrecoMax = null;
            this.NavigationManager.NavigateTo("/produtos/pagina/1");
        }

        private void Filtrar()
        {
            if (!string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.NomeCategoria) && !this.model.Categoria.HasValue)
            {
                this.NavigationManager.NavigateTo($"/produtos/procurar/{this.model.Query}/pagina/{this.model.Pagina}");
            }
            else if (!string.IsNullOrWhiteSpace(this.model.Query) && !string.IsNullOrWhiteSpace(this.NomeCategoria) && this.model.Categoria.HasValue)
            {
                this.NavigationManager.NavigateTo($"/produtos/categoria/{this.NomeCategoria}/{this.model.Categoria}/procurar/{this.model.Query}/pagina/{this.model.Pagina}");
            }
            else if (!string.IsNullOrWhiteSpace(this.NomeCategoria) && this.model.Categoria.HasValue)
            {
                this.NavigationManager.NavigateTo($"/produtos/categoria/{this.NomeCategoria}/{this.model.Categoria}/pagina/{this.model.Pagina}");
            }
            else if (string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.NomeCategoria) && !this.model.Categoria.HasValue)
            {
                this.NavigationManager.NavigateTo($"/produtos/pagina/{this.model.Pagina}");
            }
        }
    }
}

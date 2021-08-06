namespace LojaBlazor.Web.Client.Shared.Produtos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    using Models.CarrinhoCompras;

    public partial class AdicionarCarrinho
    {
        private readonly CarrinhoComprasRequestModel Model = new CarrinhoComprasRequestModel();

        public bool MostrarErros { get; set; }

        public IEnumerable<string> Erros { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string NomeProduto { get; set; }

        [Parameter]
        public int QuantidadeProduto { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        private async Task GravarAsync()
        {
            this.Model.ProductId = this.Id;

            var respostas = await this.CarrinhoComprasService.AdicionarProduto(this.Model);

            if (!respostas.Sucesso)
            {
                this.Erros = respostas.Erros;
                this.MostrarErros = true;
            }
            else
            {
                this.MostrarErros = false;
                this.NavigationManager.NavigateTo("/carrinho", forceLoad: true);
            }
        }

        private async Task ExcluirAsync()
        {
            var confirmado = await this.JsRuntime.InvokeAsync<bool>(
                "confirm",
                "Tem certeza de que deseja excluir este item?");

            if (confirmado)
            {
                var resultado = await this.ProdutosService.ExcluirAsync(this.Id);

                if (resultado.Sucesso)
                {
                    this.ToastService.ShowSuccess($"{this.NomeProduto} foi excluído com sucesso!");
                    this.NavigationManager.NavigateTo("/produtos/pagina/1");
                }
                else
                {
                    this.Erros = resultado.Erros;
                    this.MostrarErros = true;
                }
            }
        }

        private async Task AdicionarListaDesejos()
        {
            var result = await this.ListaDesejosService.AdicionarProduto(this.Id);

            if (result.Sucesso)
            {
                this.ToastService.ShowSuccess($"{this.NomeProduto} foi adicionado à sua lista de desejos!");
            }
            else
            {
                this.Erros = result.Erros;
                this.MostrarErros = true;
            }
        }

        private void IncrementarQuantidade()
        {
            if (this.Model.Quantidade < this.QuantidadeProduto)
            {
                this.Model.Quantidade++;
                this.MostrarErros = false;
            }
        }

        private void DecrementarQuantidade()
        {
            if (this.Model.Quantidade > 1)
            {
                this.Model.Quantidade--;
                this.MostrarErros = false;
            }
        }
    }
}

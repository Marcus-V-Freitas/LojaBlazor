namespace LojaBlazor.Web.Client.Shared.Produtos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    public partial class Paginacao
    {
        private List<LinkModel> Links;

        [Parameter]
        public int Pagina { get; set; } = 1;

        [Parameter]
        public int TotalPaginas { get; set; }

        [Parameter]
        public int Radius { get; set; } = 3;

        [Parameter]
        public EventCallback<int> SelecionarPagina { get; set; }

        protected override void OnParametersSet() => this.CarregarPaginas();

        private async Task PaginaInternaSelecionada(LinkModel link)
        {
            if (link.Page == this.Pagina)
            {
                return;
            }

            if (!link.Enabled)
            {
                return;
            }

            this.Pagina = link.Page;

            await this.SelecionarPagina.InvokeAsync(link.Page);
        }

        private void CarregarPaginas()
        {
            const string previous = "Previous";
            const string next = "Next";

            var isPreviousPageLinkEnabled = this.Pagina != 1;
            var previousPage = this.Pagina - 1;

            this.Links = new List<LinkModel>
            {
                new LinkModel(previousPage, isPreviousPageLinkEnabled, previous)
            };

            for (int i = 1; i <= this.TotalPaginas; i++)
            {
                if (i >= this.Pagina - this.Radius && i <= this.Pagina + this.Radius)
                {
                    this.Links.Add(new LinkModel(i)
                    {
                        Active = this.Pagina == i
                    });
                }
            }

            var isNextPageLinkEnabled = this.Pagina != this.TotalPaginas;
            var nextPage = this.Pagina + 1;

            this.Links.Add(new LinkModel(nextPage, isNextPageLinkEnabled, next));
        }

        private class LinkModel
        {
            public LinkModel(int page)
                : this(page, true)
            {
            }

            private LinkModel(int page, bool enabled)
                : this(page, enabled, page.ToString())
            {
            }

            public LinkModel(int page, bool enabled, string text)
            {
                this.Page = page;
                this.Enabled = enabled;
                this.Text = text;
            }

            public string Text { get; }

            public int Page { get; }

            public bool Enabled { get; }

            public bool Active { get; set; }
        }
    }
}

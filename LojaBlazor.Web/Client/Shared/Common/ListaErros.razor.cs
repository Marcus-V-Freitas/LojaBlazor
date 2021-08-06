namespace LojaBlazor.Web.Client.Shared.Common
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;

    public partial class ListaErros
    {
        [Parameter]
        public bool MostrarErros { get; set; }

        [Parameter]
        public IEnumerable<string> Erros { get; set; }

        private void Redefinir() => this.MostrarErros = !this.MostrarErros;
    }
}

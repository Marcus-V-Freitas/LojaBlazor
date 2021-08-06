namespace LojaBlazor.Models.Produtos
{
    using System.Collections.Generic;

    public class ProdutosBuscaResponseModel
    {
        public IEnumerable<ProdutoListagemResponseModel> Produtos { get; set; }

        public int Pagina { get; set; }

        public int TotalPaginas { get; set; }
    }
}

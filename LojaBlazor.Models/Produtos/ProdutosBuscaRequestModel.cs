namespace LojaBlazor.Models.Produtos
{
    public class ProdutosBuscaRequestModel
    {
        public string Query { get; set; }

        public int? Categoria { get; set; }

        public decimal? PrecoMin { get; set; }

        public decimal? PrecoMax { get; set; }

        public int Pagina { get; set; } = 1;
    }
}

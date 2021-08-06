namespace LojaBlazor.Models.Produtos
{
    public class ProdutosDetalhesResponseModel : ProdutoListagemResponseModel
    {
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }

        public string NomeCategoria { get; set; }
    }
}

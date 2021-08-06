namespace LojaBlazor.Models.Produtos
{
    using Common.Mapping;
    using Data.Models;

    public class ProdutoListagemResponseModel : IMapFrom<Produto>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string FonteImagem { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }
    }
}

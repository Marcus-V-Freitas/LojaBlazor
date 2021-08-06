namespace LojaBlazor.Data.Models
{
    using Contracts;

    public class CarrinhoComprasProdutos : BaseModel
    {
        public int CarrinhoComprasId { get; set; }

        public CarrinhoCompras CarrinhoCompras { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}

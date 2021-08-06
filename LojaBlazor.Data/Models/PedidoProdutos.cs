namespace LojaBlazor.Data.Models
{
    using Contracts;

    public class PedidoProdutos : BaseModel
    {
        public string PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}

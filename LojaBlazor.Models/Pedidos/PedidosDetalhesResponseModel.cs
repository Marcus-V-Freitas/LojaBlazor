namespace LojaBlazor.Models.Pedidos
{
    using System.Collections.Generic;

    public class PedidosDetalhesResponseModel : PedidosBaseResponseModel
    {
        public IEnumerable<PedidosProdutosResponseModel> Produtos { get; set; }
    }
}

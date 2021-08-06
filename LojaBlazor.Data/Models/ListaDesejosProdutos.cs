namespace LojaBlazor.Data.Models
{
    using Contracts;

    public class ListaDesejosProdutos : BaseModel
    {
        public int ListaDesejosId { get; set; }

        public ListaDesejos ListaDesejos { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
    }
}

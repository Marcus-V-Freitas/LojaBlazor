namespace LojaBlazor.Models.CarrinhoCompras
{
    using System.ComponentModel.DataAnnotations;

    using static Data.ModelConstantes.Produto;

    public class CarrinhoComprasRequestModel
    {
        [Required]
        public int ProductId { get; set; }

        [Range(QuantidadeMin, QuantidadeMax)]
        public int Quantidade { get; set; } = QuantidadeMin;
    }
}
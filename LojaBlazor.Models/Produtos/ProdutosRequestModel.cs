namespace LojaBlazor.Models.Produtos
{
    using System.ComponentModel.DataAnnotations;

    using static MensagensErro;
    using static Data.ModelConstantes.Common;
    using static Data.ModelConstantes.Produto;

    public class ProdutosRequestModel
    {
        [Required]
        [StringLength(
            TamanhoMaxNome, 
            ErrorMessage = TamanhoSenhaErrorMessage, 
            MinimumLength = TamanhoMinNome)]
        public string Nome { get; set; }

        [MaxLength(TamanhoMaxDescricao)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(TamanhoMaxUrl)]
        public string FonteImagem { get; set; }
        
        [Required]
        [Range(QuantidadeMin, QuantidadeMax)]
        public int Quantidade { get; set; }

        [Required]
        [Range(typeof(decimal), PrecoMin, PrecoMax)]
        public decimal Preco { get; set; }

        [Required]
        public int CategoriaId { get; set; }
    }
}

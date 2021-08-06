namespace LojaBlazor.Models.Categorias
{
    using System.ComponentModel.DataAnnotations;

    using static MensagensErro;
    using static Data.ModelConstantes.Common;

    public class CategoriasRequestModel
    {
        [Required]
        [StringLength(
            TamanhoMaxNome, 
            ErrorMessage = TamanhoSenhaErrorMessage, 
            MinimumLength = TamanhoMinNome)]
        public string Nome { get; set; }
    }
}

namespace LojaBlazor.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static MensagensErro;
    using static Data.ModelConstantes.Common;

    public class TrocarConfiguracoesRequestModel
    {
        [Required]
        [StringLength(
            TamanhoMaxNome,
            ErrorMessage = TamanhoSenhaErrorMessage,
            MinimumLength = TamanhoMinNome)]
        public string PrimeiroNome { get; set; }

        [Required]
        [StringLength(
            TamanhoMaxNome,
            ErrorMessage = TamanhoSenhaErrorMessage,
            MinimumLength = TamanhoMinNome)]
        public string Sobrenome { get; set; }
    }
}
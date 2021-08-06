namespace LojaBlazor.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static MensagensErro;
    using static Data.ModelConstantes.Common;
    using static Data.ModelConstantes.Identity;

    public class RegistrarRequestModel : LoginRequestModel
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

        [Required]
        [MinLength(TamanhoMinSenha)]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = SenhasNaoCorrespondemErrorMessage)]
        public string ConfirmarSenha { get; set; }
    }
}

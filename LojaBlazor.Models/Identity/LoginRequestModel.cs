namespace LojaBlazor.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static Data.ModelConstantes.Identity;

    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        [MinLength(TamanhoMinEmail)]
        [MaxLength(TamanhoMaxEmail)]
        public string Email { get; set; }

        [Required]
        [MinLength(TamanhoMinSenha)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}

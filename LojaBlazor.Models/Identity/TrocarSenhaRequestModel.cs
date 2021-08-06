namespace LojaBlazor.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static Data.ModelConstantes.Identity;

    public class TrocarSenhaRequestModel
    {
        [Required]
        [MinLength(TamanhoMinSenha)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [MinLength(TamanhoMinSenha)]
        [DataType(DataType.Password)]
        public string SenhaNova { get; set; }

        [Required]
        [MinLength(TamanhoMinSenha)]
        [DataType(DataType.Password)]
        [Compare(nameof(SenhaNova))]
        public string ConfirmarSenhaNova { get; set; }
    }
}

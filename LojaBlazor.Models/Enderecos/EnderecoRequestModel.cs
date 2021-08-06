namespace LojaBlazor.Models.Enderecos
{
    using System.ComponentModel.DataAnnotations;

    using static Data.ModelConstantes.Endereco;

    public class EnderecoRequestModel
    {
        [Required]
        [MaxLength(TamanhoMaxPais)]
        public string Pais { get; set; }

        [Required]
        [MaxLength(TamanhoMaxEstado)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(TamanhoMinCidade)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(TamanhoMaxDescricao)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(TamanhoMaxCodigoPostal)]
        public string CodigoPostal { get; set; }

        [Required]
        [MinLength(TamanhoMinNumeroTelefone)]
        [MaxLength(TamanhoMaxNumeroTelefone)]
        [RegularExpression(RegexNumeroTelefone)]
        public string NumeroTelefone { get; set; }
    }
}

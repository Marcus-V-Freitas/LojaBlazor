namespace LojaBlazor.Models.Enderecos
{
    using Common.Mapping;
    using Data.Models;

    public class EnderecoListagemResponseModel : IMapFrom<Endereco>
    {
        public int Id { get; set; }

        public string Pais { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Descricao { get; set; }

        public string CodigoPostal { get; set; }

        public string NumeroTelefone { get; set; }
    }
}

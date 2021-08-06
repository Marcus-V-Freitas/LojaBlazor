namespace LojaBlazor.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Endereco : BaseDeletavelModel
    {
        public int Id { get; set; }

        public string Pais { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Descricao { get; set; }

        public string CodigoPostal { get; set; }

        public string NumeroTelefone { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Pedido> Pedidos { get; } = new HashSet<Pedido>();
    }
}
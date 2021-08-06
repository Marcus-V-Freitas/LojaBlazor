namespace LojaBlazor.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class ListaDesejos : BaseModel
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuarios { get; set; }

        public ICollection<ListaDesejosProdutos> Produtos { get; } = new HashSet<ListaDesejosProdutos>();
    }
}

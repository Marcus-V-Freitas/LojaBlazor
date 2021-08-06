namespace LojaBlazor.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class CarrinhoCompras : BaseModel
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<CarrinhoComprasProdutos> Produtos { get; } = new HashSet<CarrinhoComprasProdutos>();
    }
}

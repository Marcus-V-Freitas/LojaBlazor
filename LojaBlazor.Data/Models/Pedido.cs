namespace LojaBlazor.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Pedido : BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int EnderecoEntregaId { get; set; }

        public Endereco EnderecoEntrega { get; set; }

        public ICollection<PedidoProdutos> Produtos { get; } = new HashSet<PedidoProdutos>();
    }
}

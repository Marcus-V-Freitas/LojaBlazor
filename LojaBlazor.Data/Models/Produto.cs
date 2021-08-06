namespace LojaBlazor.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Produto : BaseDeletavelModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string FonteImagem { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public ICollection<ListaDesejosProdutos> ListaDesejos { get; } = new HashSet<ListaDesejosProdutos>();

        public ICollection<CarrinhoComprasProdutos> CarrinhosCompras { get; } = new HashSet<CarrinhoComprasProdutos>();

        public ICollection<PedidoProdutos> Pedidos { get; } = new HashSet<PedidoProdutos>();
    }
}
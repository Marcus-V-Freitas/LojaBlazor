namespace LojaBlazor.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Categoria : BaseDeletavelModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; } = new HashSet<Produto>();
    }
}
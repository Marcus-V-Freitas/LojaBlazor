namespace LojaBlazor.Data.Seed
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class CategoriasDados : IDadosInicial
    {
        public Type TipoEntidade => typeof(Categoria);

        public IEnumerable<object> RecuperarDados()
            => new List<Categoria>
            {
                new Categoria { Nome = "Fashion" },
                new Categoria { Nome = "Electronics" },
                new Categoria { Nome = "Books, Movies & Music" }
            };
    }
}

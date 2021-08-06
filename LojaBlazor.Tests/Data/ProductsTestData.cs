namespace LojaBlazor.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LojaBlazor.Data.Models;

    public static class ProductsTestData
    {
        public static List<Produto> GetProducts(int count)
            => Enumerable
                .Range(1, count)
                .Select(i => new Produto
                {
                    Nome = $"Product {i}",
                    Descricao = $"Description {i}",
                    FonteImagem = $"Image {i}",
                    Quantidade = i,
                    Preco = i + 0.5m,
                    CategoriaId = i
                })
                .ToList();
    }
}

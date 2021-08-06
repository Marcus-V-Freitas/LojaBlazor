namespace LojaBlazor.Data.Seed
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class ProdutosDados : IDadosInicial
    {
        public Type TipoEntidade => typeof(Produto);

        public IEnumerable<object> RecuperarDados()
            => new List<Produto>
            {
                new Produto
                {
                    Nome = "Cool T-Shirt",
                    Descricao = "The Cool T-Shirt is made from soft cotton and features a clean print.",
                    FonteImagem = "https://gorilla.bg/userfiles/productlargeimages/product_256.jpg",
                    Preco = 19.99m,
                    Quantidade = 10,
                    CategoriaId = 1
                },
                new Produto
                {
                    Nome = "Super Hero Marvel Sweatshirt",
                    Descricao = "The Super Hero Marvel Sweatshirt is made from soft cotton.",
                    FonteImagem = "https://cdn11.bigcommerce.com/s-pkla4xn3/images/stencil/1280x1280/products/7404/67088/New-Super-Hero-Marvel-Sweatshirts-Fashion-Cotton-Men-Hoodies-Marvel-Cool-Printed-Sweatshirts-Men-Clothing-Free__23706.1527569968.jpg?c=2&imbypass=on",
                    Preco = 50,
                    Quantidade = 30,
                    CategoriaId = 1
                },
                new Produto
                {
                    Nome = "Beats by Dr. Dre Solo3 Wireless On-Ear Headphones",
                    Descricao = "Beats Solo 3 is easy to set up, simply power on and hold near your iPhone, Apple Watch, iPad and Mac. Bluetooth technology makes it easy to instantly enjoy music from your Apple devices.",
                    FonteImagem = "https://i.ebayimg.com/images/g/OkQAAOSwFdRe18Yq/s-l1600.jpg",
                    Preco = 109.60m,
                    Quantidade = 10,
                    CategoriaId = 2
                },
                new Produto
                {
                    Nome = "Apple Watch Series 5",
                    Descricao = "Keep your workouts fresh and enjoyable by streaming your favorite audio with the Apple Watch Series 5. The Series 5 has access to the Apple Music library, letting you stream your favorite albums, podcasts, and audiobooks.",
                    FonteImagem = "https://static.plasico.bg/thumbs/12/mwvf2bsa.jpg",
                    Preco = 366.98m,
                    Quantidade = 10,
                    CategoriaId = 2
                },
                new Produto
                {
                    Nome = "Code Complete - Second Edition",
                    Descricao = "CODE COMPLETE has been helping developers write better software for more than a decade.",
                    FonteImagem = "https://i.ebayimg.com/images/g/55gAAOSwIqtfW63B/s-l500.png",
                    Preco = 35.99m,
                    Quantidade = 10,
                    CategoriaId = 3
                },
                new Produto
                {
                    Nome = "Rick and Morty: Season 3 - Blu-Ray",
                    Descricao = "An animated series that follows the exploits of a super scientist and his not-so-bright grandson.",
                    FonteImagem = "https://www.augoods.com.au/assets/full/DVD-LN-9322225226746.jpg?20200703062244",
                    Preco = 28.95m,
                    Quantidade = 10,
                    CategoriaId = 3
                }
            };
    }
}

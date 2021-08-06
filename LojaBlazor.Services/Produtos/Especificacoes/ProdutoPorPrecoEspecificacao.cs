namespace LojaBlazor.Services.Produtos.Especificacoes
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    internal class ProdutoPorPrecoEspecificacao : Especificacao<Produto>
    {
        private readonly decimal minPrice;
        private readonly decimal maxPrice;

        internal ProdutoPorPrecoEspecificacao(
            decimal? minPrice = default,
            decimal? maxPrice = decimal.MaxValue)
        {
            this.minPrice = minPrice ?? default;
            this.maxPrice = maxPrice ?? decimal.MaxValue;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
            => product => this.minPrice < product.Preco && this.maxPrice > product.Preco;
    }
}

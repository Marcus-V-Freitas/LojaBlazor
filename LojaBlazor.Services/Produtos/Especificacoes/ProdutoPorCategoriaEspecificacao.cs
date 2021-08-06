namespace LojaBlazor.Services.Produtos.Especificacoes
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    internal class ProdutoPorCategoriaEspecificacao : Especificacao<Produto>
    {
        private readonly int? category;

        internal ProdutoPorCategoriaEspecificacao(int? category)
            => this.category = category;

        protected override bool Include => this.category != null;

        public override Expression<Func<Produto, bool>> ToExpression()
            => product => product.Categoria.Id == this.category;
    }
}
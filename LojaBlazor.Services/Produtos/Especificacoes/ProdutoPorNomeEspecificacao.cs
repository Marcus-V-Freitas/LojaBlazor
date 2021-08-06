namespace LojaBlazor.Services.Produtos.Especificacoes
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    internal class ProdutoPorNomeEspecificacao : Especificacao<Produto>
    {
        private readonly string name;

        internal ProdutoPorNomeEspecificacao(string name) => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Produto, bool>> ToExpression()
            => product => product.Nome.ToLower().Contains(this.name.ToLower());
    }
}

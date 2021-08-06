namespace LojaBlazor.Models.CarrinhoCompras
{
    using AutoMapper;

    using Common.Mapping;
    using Data.Models;

    public class CarrinhoComprasProdutoResponseModel : IMapFrom<CarrinhoComprasProdutos>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string FonteImagem { get; set; }

        public int Quantidade { get; set; }

        public int QuantidadeEstoque { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarrinhoComprasProdutos, CarrinhoComprasProdutoResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(c => c.Produto.Id))
                .ForMember(m => m.Nome, m => m
                    .MapFrom(c => c.Produto.Nome))
                .ForMember(m => m.Preco, m => m
                    .MapFrom(c => c.Produto.Preco))
                .ForMember(m => m.FonteImagem, m => m
                    .MapFrom(c => c.Produto.FonteImagem))
                .ForMember(m => m.Quantidade, m => m
                    .MapFrom(c => c.Quantidade))
                .ForMember(m => m.QuantidadeEstoque, m => m
                    .MapFrom(c => c.Produto.Quantidade));
    }
}
namespace LojaBlazor.Models.Pedidos
{
    using AutoMapper;

    using Common.Mapping;
    using Data.Models;

    public class PedidosProdutosResponseModel : IMapFrom<PedidoProdutos>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string FonteImagem { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<PedidoProdutos, PedidosProdutosResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(op => op.Produto.Id))
                .ForMember(m => m.Nome, m => m
                    .MapFrom(op => op.Produto.Nome))
                .ForMember(m => m.FonteImagem, m => m
                    .MapFrom(op => op.Produto.FonteImagem))
                .ForMember(m => m.Quantidade, m => m
                    .MapFrom(op => op.Quantidade))
                .ForMember(m => m.Preco, m => m
                    .MapFrom(op => op.Produto.Preco));
    }
}
namespace LojaBlazor.Models.Pedidos
{
    using AutoMapper;

    using Data.Models;

    public class PedidosListagemResponseModel : PedidosBaseResponseModel
    {
        public string NomeProduto { get; set; }

        public string FonteImagemProduto { get; set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<PedidoProdutos, PedidosListagemResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(op => op.Pedido.Id))
                .ForMember(m => m.CriadoEm, m => m
                    .MapFrom(op => op.Pedido.CriadoEm.ToShortDateString()))
                .ForMember(m => m.NomeProduto, m => m
                    .MapFrom(op => op.Produto.Nome))
                .ForMember(m => m.FonteImagemProduto, m => m
                    .MapFrom(o => o.Produto.FonteImagem));
    }
}

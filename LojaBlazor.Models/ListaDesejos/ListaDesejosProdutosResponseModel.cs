namespace LojaBlazor.Models.ListaDesejos
{
    using AutoMapper;

    using Common.Mapping;
    using Data.Models;

    public class ListaDesejosProdutosResponseModel : IMapFrom<ListaDesejosProdutos>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string FonteImagem { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<ListaDesejosProdutos, ListaDesejosProdutosResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(c => c.Produto.Id))
                .ForMember(m => m.Nome, m => m
                    .MapFrom(c => c.Produto.Nome))
                .ForMember(m => m.Descricao, m => m
                    .MapFrom(c => c.Produto.Descricao))
                .ForMember(m => m.FonteImagem, m => m
                    .MapFrom(c => c.Produto.FonteImagem))
                .ForMember(m => m.Preco, m => m
                    .MapFrom(c => c.Produto.Preco));

    }
}

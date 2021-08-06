namespace LojaBlazor.Models.Pedidos
{
    using System.Globalization;

    using AutoMapper;

    using Common.Mapping;
    using Data.Models;

    public class PedidosBaseResponseModel : IMapFrom<Pedido>
    {
        public string Id { get; set; }

        public string CriadoEm { get; set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Pedido, PedidosDetalhesResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(o => o.Id))
                .ForMember(m => m.CriadoEm, m => m
                    .MapFrom(o => o.CriadoEm.ToString(CultureInfo.InvariantCulture)));
    }
}

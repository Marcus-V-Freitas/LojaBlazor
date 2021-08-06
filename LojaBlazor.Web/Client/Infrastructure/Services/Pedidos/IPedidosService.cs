namespace LojaBlazor.Web.Client.Infrastructure.Services.Pedidos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LojaBlazor.Models.Pedidos;

    public interface IPedidosService
    {
        Task<string> Compra(PedidosRequestModel model);

        Task<PedidosDetalhesResponseModel> Detalhes(string id);

        Task<IEnumerable<PedidosListagemResponseModel>> Meu();
    }
}
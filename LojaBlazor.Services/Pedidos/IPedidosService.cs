namespace LojaBlazor.Services.Pedidos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LojaBlazor.Models.Pedidos;
    using Common;

    public interface IPedidosService : IService
    {
        Task<string> CompraAsync(PedidosRequestModel model, string userId);

        Task<PedidosDetalhesResponseModel> DetalhesAsync(string id);

        Task<IEnumerable<PedidosListagemResponseModel>> UsuarioPorIdAsync(string userId);
    }
}
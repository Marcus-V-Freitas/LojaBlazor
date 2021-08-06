namespace LojaBlazor.Services.ListaDesejos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.ListaDesejos;

    public interface IListaDesejosService : IService
    {
        Task<Resultado> AddProductAsync(int productId, string userId);

        Task<Resultado> RemoveProductAsync(int productId, string userId);

        Task<IEnumerable<ListaDesejosProdutosResponseModel>> ByUserAsync(string userId);
    }
}

namespace LojaBlazor.Services.Enderecos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.Enderecos;

    public interface IEnderecosService : IService
    {
        Task<int> CreateAsync(EnderecoRequestModel model, string userId);

        Task<Resultado> DeleteAsync(int id, string userId);

        Task<IEnumerable<EnderecoListagemResponseModel>> ByUserAsync(string userId);
    }
}
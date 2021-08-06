namespace LojaBlazor.Web.Client.Infrastructure.Services.Enderecos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;
    using Models.Enderecos;

    public interface IEnderecosService
    {
        Task<int> CriarAsync(EnderecoRequestModel model);

        Task<Resultado> ExcluirAsync(int id);

        Task<IEnumerable<EnderecoListagemResponseModel>> Meu();
    }
}

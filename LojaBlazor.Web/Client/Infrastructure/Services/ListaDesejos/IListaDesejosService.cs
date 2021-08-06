namespace LojaBlazor.Web.Client.Infrastructure.Services.ListaDesejos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LojaBlazor.Models.ListaDesejos;
    using Models;

    public interface IListaDesejosService
    {
        Task<Resultado> AdicionarProduto(int id);

        Task<Resultado> ExcluirProduto(int id);

        Task<IEnumerable< ListaDesejosProdutosResponseModel>> Meu();
    }
}

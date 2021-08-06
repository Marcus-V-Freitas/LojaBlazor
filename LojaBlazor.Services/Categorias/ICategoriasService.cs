namespace LojaBlazor.Services.Categorias
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.Categorias;

    public interface ICategoriasService : IService
    {
        Task<int> CreateAsync(CategoriasRequestModel model);

        Task<Resultado> UpdateAsync(int id, CategoriasRequestModel model);

        Task<Resultado> DeleteAsync(int id);

        Task<IEnumerable<CategoriaListagemResponseModel>> AllAsync();
    }
}
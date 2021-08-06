namespace LojaBlazor.Web.Client.Infrastructure.Services.Categorias
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Categorias;

    public interface ICategoriasService
    {
        Task<IEnumerable<CategoriaListagemResponseModel>> Todos();
    }
}

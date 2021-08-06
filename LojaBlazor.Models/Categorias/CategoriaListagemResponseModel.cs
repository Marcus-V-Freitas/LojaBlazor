namespace LojaBlazor.Models.Categorias
{
    using Common.Mapping;
    using Data.Models;

    public class CategoriaListagemResponseModel : IMapFrom<Categoria>
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
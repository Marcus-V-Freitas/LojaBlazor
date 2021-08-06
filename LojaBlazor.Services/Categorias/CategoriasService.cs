namespace LojaBlazor.Services.Categorias
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using Models.Categorias;

    public class CategoriasService : BaseService<Categoria>, ICategoriasService
    {
        public CategoriasService(LojaBlazorDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<int> CreateAsync(CategoriasRequestModel model)
        {
            var category = new Categoria
            {
                Nome = model.Nome
            };

            await this.Data.AddAsync(category);
            await this.Data.SaveChangesAsync();

            return category.Id;
        }

        public async Task<Resultado> UpdateAsync(
            int id, CategoriasRequestModel model)
        {
            var category = await this.FindByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            category.Nome = model.Nome;

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Resultado> DeleteAsync(int id)
        {
            var category = await this.FindByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            this.Data.Remove(category);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CategoriaListagemResponseModel>> AllAsync()
            => await this.Mapper
                .ProjectTo<CategoriaListagemResponseModel>(this
                    .TodosAsNoTracking())
                .ToListAsync();

        private async Task<Categoria> FindByIdAsync(
            int id)
            => await this
                .Todos()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}

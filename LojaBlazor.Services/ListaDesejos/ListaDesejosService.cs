namespace LojaBlazor.Services.ListaDesejos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using Models.ListaDesejos;

    public class ListaDesejosService : BaseService<ListaDesejos>, IListaDesejosService
    {
        public ListaDesejosService(LojaBlazorDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<Resultado> AddProductAsync(
            int productId, string userId)
        {
            var wishlist = await this
                .Todos()
                .FirstOrDefaultAsync(w => w.UsuarioId == userId);

            wishlist ??= new ListaDesejos
            {
                UsuarioId = userId
            };

            var wishlistProduct = new ListaDesejosProdutos
            {
                ListaDesejos = wishlist,
                ProdutoId = productId
            };

            await this.Data.AddAsync(wishlistProduct);
            await this.Data.SaveChangesAsync();

            return Resultado.Success;
        }

        public async Task<Resultado> RemoveProductAsync(
            int productId, string userId)
        {
            var wishlistProduct = await this
                .AllByUserId(userId)
                .FirstOrDefaultAsync(w => w.ProdutoId == productId);

            if (wishlistProduct == null)
            {
                return "This user cannot delete products from this wishlist.";
            }

            this.Data.Remove(wishlistProduct);

            await this.Data.SaveChangesAsync();

            return Resultado.Success;
        }

        public async Task<IEnumerable<ListaDesejosProdutosResponseModel>> ByUserAsync(
            string userId)
            => await this.Mapper
                .ProjectTo<ListaDesejosProdutosResponseModel>(this
                    .AllByUserId(userId)
                    .AsNoTracking())
                .ToListAsync();

        private IQueryable<ListaDesejosProdutos> AllByUserId(
            string userId)
            => this
                .Todos()
                .Where(w => w.UsuarioId == userId)
                .SelectMany(w => w.Produtos);
    }
}

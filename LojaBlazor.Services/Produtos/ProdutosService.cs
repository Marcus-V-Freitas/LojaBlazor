namespace LojaBlazor.Services.Produtos
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using Models.Produtos;
    using Especificacoes;

    public class ProdutosService : BaseService<Produto>, IProdutosService
    {
        private const int ProductsPerPage = 6;

        public ProdutosService(LojaBlazorDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<int> CreateAsync(ProdutosRequestModel model)
        {
            var product = new Produto
            {
                Nome = model.Nome,
                Descricao = model.Descricao,
                FonteImagem = model.FonteImagem,
                Quantidade = model.Quantidade,
                Preco = model.Preco,
                CategoriaId = model.CategoriaId
            };

            await this.Data.AddAsync(product);
            await this.Data.SaveChangesAsync();

            return product.Id;
        }

        public async Task<Resultado> UpdateAsync(
            int id, ProdutosRequestModel model)
        {
            var product = await this.FindByIdAsync(id);

            if (product == null)
            {
                return false;
            }

            product.Nome = model.Nome;
            product.Descricao = model.Descricao;
            product.FonteImagem = model.FonteImagem;
            product.Quantidade = model.Quantidade;
            product.Preco = model.Preco;
            product.CategoriaId = model.CategoriaId;

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Resultado> DeleteAsync(int id)
        {
            var product = await this.FindByIdAsync(id);

            if (product == null)
            {
                return false;
            }

            this.Data.Remove(product);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<ProdutosDetalhesResponseModel> DetailsAsync(
            int id)
            => await this.Mapper
                .ProjectTo<ProdutosDetalhesResponseModel>(this
                    .TodosAsNoTracking()
                    .Where(p => p.Id == id))
                .FirstOrDefaultAsync();

        public async Task<ProdutosBuscaResponseModel> SearchAsync(
            ProdutosBuscaRequestModel model)
        {
            var specification = this.GetProductSpecification(model);

            var products = await this.Mapper
                .ProjectTo<ProdutoListagemResponseModel>(this
                    .TodosAsNoTracking()
                    .Where(specification)
                    .Skip((model.Pagina - 1) * ProductsPerPage)
                    .Take(ProductsPerPage))
                .ToListAsync();

            var totalPages = await this.GetTotalPages(model);

            return new ProdutosBuscaResponseModel
            {
                Produtos = products,
                Pagina = model.Pagina,
                TotalPaginas = totalPages
            };
        }

        private async Task<int> GetTotalPages(
            ProdutosBuscaRequestModel model)
        {
            var specification = this.GetProductSpecification(model);

            var total = await this
                .TodosAsNoTracking()
                .Where(specification)
                .CountAsync();

            return (int)Math.Ceiling((double)total / ProductsPerPage);
        }

        private async Task<Produto> FindByIdAsync(
            int id)
            => await this
                .Todos()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

        private Especificacao<Produto> GetProductSpecification(
            ProdutosBuscaRequestModel model)
            => new ProdutoPorNomeEspecificacao(model.Query)
                .And(new ProdutoPorPrecoEspecificacao(model.PrecoMin, model.PrecoMax))
                .And(new ProdutoPorCategoriaEspecificacao(model.Categoria));
    }
}

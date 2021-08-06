namespace LojaBlazor.Tests.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Shouldly;
    using Xunit;

    using LojaBlazor.Services.Produtos;
    using Common;
    using Data;
    using Models.Produtos;

    public class ProductsServiceTests : SetupFixture
    {
        private readonly IProdutosService products;

        public ProductsServiceTests()
            => this.products = new ProdutosService(this.Data, this.Mapper);

        [Theory]
        [InlineData("Product 1", "Description 1", "Image 1", 3, 3.50, 1)]
        [InlineData("Product 2", "Description 2", "Image 2", 6, 6.50, 2)]
        [InlineData("Product 3", "Description 3", "Image 3", 9, 9.99, 3)]
        public async Task CreateShouldWorkCorrectly(
            string name,
            string description,
            string imageSource,
            int quantity,
            decimal price,
            int categoryId)
        {
            var request = new ProdutosRequestModel
            {
                Nome = name,
                Descricao = description,
                FonteImagem = imageSource,
                Quantidade = quantity,
                Preco = price,
                CategoriaId = categoryId
            };

            var id = await this.products.CreateAsync(request);

            var product = await this.Data.Produtos.FindAsync(id);

            product.Id.ShouldBe(id);
            product.Nome.ShouldBe(request.Nome);
            product.Descricao.ShouldBe(request.Descricao);
            product.FonteImagem.ShouldBe(request.FonteImagem);
            product.Quantidade.ShouldBe(request.Quantidade);
            product.Preco.ShouldBe(request.Preco);
            product.CategoriaId.ShouldBe(request.CategoriaId);
        }

        [Theory]
        [InlineData(1, "Updated 1", "Updated description 1", "Updated image 1", 3, 3.50, 1)]
        [InlineData(2, "Updated 2", "Updated description 2", "Updated image 2", 6, 6.50, 2)]
        [InlineData(3, "Updated 3", "Updated description 3", "Updated image 3", 9, 9.99, 3)]
        public async Task UpdateShouldWorkCorrectly(
            int count,
            string name,
            string description,
            string imageSource,
            int quantity,
            decimal price,
            int categoryId)
        {
            const int id = 1;

            await this.AddFakeProducts(count);

            var request = new ProdutosRequestModel
            {
                Nome = name,
                Descricao = description,
                FonteImagem = imageSource,
                Quantidade = quantity,
                Preco = price,
                CategoriaId = categoryId
            };

            var result = await this.products.UpdateAsync(id, request);

            var product = await this.Data.Produtos.FindAsync(id);

            result.Sucesso.ShouldBeTrue();

            product.Id.ShouldBe(id);
            product.Nome.ShouldBe(request.Nome);
            product.Descricao.ShouldBe(request.Descricao);
            product.FonteImagem.ShouldBe(request.FonteImagem);
            product.Quantidade.ShouldBe(request.Quantidade);
            product.Preco.ShouldBe(request.Preco);
            product.CategoriaId.ShouldBe(request.CategoriaId);
        }

        [Fact]
        public async Task DeleteShouldReturnSucceededResultWhenProductIsDeleted()
        {
            await this.AddFakeProducts(1);

            var result = await this.products.DeleteAsync(1);

            result.Sucesso.ShouldBeTrue();
        }

        [Fact]
        public async Task DeleteShouldSetIsDeletedToTrue()
        {
            await this.AddFakeProducts(1);

            var result = await this.products.DeleteAsync(1);

            var product = await this
                .Data
                .Produtos
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync();

            result.Sucesso.ShouldBeTrue();
            product.ShouldNotBeNull();
            product.EstaDeletado.ShouldBeTrue();
        }

        [Fact]
        public async Task DeleteShouldReturnNotSucceededResultWhenProductIsNotFound()
        {
            var result = await this.products.DeleteAsync(1);

            result.Sucesso.ShouldBeFalse();
        }

        private async Task AddFakeProducts(int count)
        {
            var fakes = ProductsTestData.GetProducts(count);

            await this.Data.AddRangeAsync(fakes);
            await this.Data.SaveChangesAsync();
        }
    }
}

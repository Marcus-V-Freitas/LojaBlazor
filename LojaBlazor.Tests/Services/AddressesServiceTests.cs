namespace LojaBlazor.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    using LojaBlazor.Services.Enderecos;
    using Common;
    using Data;
    using Models.Enderecos;

    public class AddressesServiceTests : SetupFixture
    {
        private readonly IEnderecosService addresses;

        public AddressesServiceTests()
            => this.addresses = new EnderecosService(this.Data, this.Mapper);

        [Theory]
        [InlineData("Country 1", "State 1", "City 1", "Test description 1", "1000", "0888888888")]
        [InlineData("Country 2", "State 2", "City 2", "Test description 2", "2000", "0888888888")]
        [InlineData("Country 3", "State 3", "City 3", "Test description 3", "3000", "0888888888")]
        public async Task CreateShouldWorkCorrectly(
            string country,
            string state,
            string city,
            string description,
            string postalCode,
            string phoneNumber)
        {
            const string userId = TestUser.Identifier;

            var request = new EnderecoRequestModel
            {
                Pais = country,
                Estado = state,
                Cidade = city,
                Descricao = description,
                CodigoPostal = postalCode,
                NumeroTelefone = phoneNumber
            };

            var id = await this.addresses.CreateAsync(request, userId);

            var address = await this.Data.Enderecos.FindAsync(id);

            address.Id.ShouldBe(id);
            address.Pais.ShouldBe(request.Pais);
            address.Estado.ShouldBe(request.Estado);
            address.Descricao.ShouldBe(request.Descricao);
            address.CodigoPostal.ShouldBe(request.CodigoPostal);
            address.NumeroTelefone.ShouldBe(request.NumeroTelefone);
            address.UsuarioId.ShouldBe(userId);
        }

        [Fact]
        public async Task DeleteShouldReturnSucceededResultWhenAddressIsDeleted()
        {
            await this.AddFakeAddresses(1);

            var result = await this.addresses.DeleteAsync(1, TestUser.Identifier);

            result.Sucesso.ShouldBeTrue();
        }

        [Fact]
        public async Task DeleteShouldSetIsDeletedToTrue()
        {
            await this.AddFakeAddresses(1);

            var result = await this.addresses.DeleteAsync(1, TestUser.Identifier);

            var address = await this
                .Data
                .Enderecos
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync();

            result.Sucesso.ShouldBeTrue();
            address.ShouldNotBeNull();
            address.EstaDeletado.ShouldBeTrue();
        }

        [Fact]
        public async Task DeleteShouldReturnNotSucceededResultWhenAddressIsNotFound()
        {
            var result = await this.addresses.DeleteAsync(1, TestUser.Identifier);

            result.Sucesso.ShouldBeFalse();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public async Task ByUserShouldReturnCurrentUserAddresses(int count)
        {
            await this.AddFakeAddresses(count);

            var actual = await this.addresses.ByUserAsync(TestUser.Identifier);

            actual.Count().ShouldBe(count);
            actual.ShouldBeAssignableTo<IEnumerable<EnderecoListagemResponseModel>>();
        }

        private async Task AddFakeAddresses(int count)
        {
            var fakes = AddressesTestData.GetAddresses(count);

            await this.Data.AddRangeAsync(fakes);
            await this.Data.SaveChangesAsync();
        }
    }
}

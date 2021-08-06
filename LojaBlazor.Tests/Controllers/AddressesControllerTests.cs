namespace LojaBlazor.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    using Data;
    using Models.Enderecos;
    using Web.Server.Controllers;

    public class AddressesControllerTests
    {
        [Fact]
        public void ShouldHaveRestrictionsForAuthorizedUsers()
            => MyController<EnderecosController>
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests());

        [Theory]
        [InlineData(3)]
        [InlineData(9)]
        [InlineData(12)]
        public void MineShouldReturnResultWithCorrectModel(int count)
            => MyController<EnderecosController>
                .Instance(instance => instance
                    .WithUser()
                    .WithData(AddressesTestData.GetAddresses(count)))
                .Calling(c => c.Mine())
                .ShouldReturn()
                .ResultOfType<IEnumerable<EnderecoListagemResponseModel>>(result => result
                    .Passing(addressListing => addressListing
                        .Count()
                        .ShouldBe(count)));

        [Fact]
        public void CreateShouldHaveRestrictionsForHttpPostOnly()
            => MyController<EnderecosController>
                .Calling(c => c.Create(With.Empty<EnderecoRequestModel>()))
                .ShouldHave()
                .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post));

        [Theory]
        [InlineData("Country 1", "State 1", "City 1", "Test description 1", "1000", "+359888888888")]
        public void CreateShouldReturnCreatedResultWhenValidModelState(
            string country,
            string state,
            string city,
            string description,
            string postalCode,
            string phoneNumber)
            => MyController<EnderecosController>
                .Instance(instance => instance
                    .WithUser())
                .Calling(c => c.Create(new EnderecoRequestModel
                {
                    Pais = country,
                    Estado = state,
                    Cidade = city,
                    Descricao = description,
                    CodigoPostal = postalCode,
                    NumeroTelefone = phoneNumber
                }))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .Created();

        [Fact]
        public void CreateShouldHaveInvalidModelStateWhenRequestModelIsInvalid()
            => MyController<EnderecosController>
                .Calling(c => c.Create(new EnderecoRequestModel()))
                .ShouldHave()
                .InvalidModelState();

        [Fact]
        public void DeleteShouldHaveRestrictionsForHttpDeleteOnly()
            => MyController<EnderecosController>
                .Calling(c => c.Delete(With.Any<int>()))
                .ShouldHave()
                .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Delete));

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DeleteShouldReturnOkResultWhenAddressDeleted(int id)
            => MyController<EnderecosController>
                .Instance(instance => instance
                    .WithUser()
                    .WithData(AddressesTestData.GetAddresses(3)))
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .Ok();

        [Fact]
        public void DeleteShouldReturnBadRequestWhenAddressIdIsNotExisting()
            => MyController<EnderecosController>
                .Instance(instance => instance
                    .WithUser())
                .Calling(c => c.Delete(With.Any<int>()))
                .ShouldReturn()
                .BadRequest();
    }
}

namespace LojaBlazor.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyTested.AspNetCore.Mvc;

    using LojaBlazor.Data.Models;

    public static class AddressesTestData
    {
        public static List<Endereco> GetAddresses(int count, bool sameUser = true)
        {
            var user = new Usuario
            {
                Id = TestUser.Identifier,
                UserName = TestUser.Username
            };

            var addresses = Enumerable
                .Range(1, count)
                .Select(i => new Endereco
                {
                    Id = i,
                    Pais = $"Country {i}",
                    Estado = $"State {i}",
                    Cidade = $"City {i}",
                    Descricao = $"Description {i}",
                    CodigoPostal = $"{i}{i}{i}{i}",
                    NumeroTelefone = "0888888888",
                    Usuario = sameUser ? user : new Usuario
                    {
                        Id = $"User Id {i}",
                        UserName = $"User {i}"
                    }
                })
                .ToList();

            return addresses;
        }
    }
}

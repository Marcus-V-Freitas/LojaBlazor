namespace LojaBlazor.Tests.Common
{
    using System;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using LojaBlazor.Data;
    using Web.Server.Infrastructure;

    public abstract class SetupFixture : IDisposable
    {
        protected SetupFixture()
        {
            this.Data = InitializeDbContext();
            this.Mapper = InitializeAutoMapper();
        }

        protected LojaBlazorDbContext Data { get; }

        protected IMapper Mapper { get; }

        public void Dispose() => this.Data?.Dispose();

        private static LojaBlazorDbContext InitializeDbContext()
        {
            var options = new DbContextOptionsBuilder<LojaBlazorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new LojaBlazorDbContext(options);
        }

        private static IMapper InitializeAutoMapper()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

            return new Mapper(configuration);
        }
    }
}

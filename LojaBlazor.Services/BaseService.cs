namespace LojaBlazor.Services
{
    using System.Linq;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;

    public abstract class BaseService<TEntity>
        where TEntity : class
    {
        protected BaseService(LojaBlazorDbContext data, IMapper mapper)
        {
            this.Data = data;
            this.Mapper = mapper;
        }

        protected LojaBlazorDbContext Data { get; }

        protected IMapper Mapper { get; }

        protected IQueryable<TEntity> Todos() => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> TodosAsNoTracking() => this.Todos().AsNoTracking();
    }
}

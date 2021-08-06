namespace LojaBlazor.Services.Enderecos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using Models.Enderecos;

    public class EnderecosService : BaseService<Endereco>, IEnderecosService
    {
        public EnderecosService(LojaBlazorDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<int> CreateAsync(
            EnderecoRequestModel model, string userId)
        {
            var address = new Endereco
            {
                Pais = model.Pais,
                Estado = model.Estado,
                Cidade = model.Cidade,
                Descricao = model.Descricao,
                CodigoPostal = model.CodigoPostal,
                NumeroTelefone = model.NumeroTelefone,
                UsuarioId = userId
            };

            await this.Data.AddAsync(address);
            await this.Data.SaveChangesAsync();

            return address.Id;
        }

        public async Task<Resultado> DeleteAsync(
            int id, string userId)
        {
            var address = await this
                .Todos()
                .Where(a => a.Id == id && a.UsuarioId == userId)
                .FirstOrDefaultAsync();

            if (address == null)
            {
                return "This user cannot delete this address.";
            }

            this.Data.Remove(address);

            await this.Data.SaveChangesAsync();

            return Resultado.Success;
        }

        public async Task<IEnumerable<EnderecoListagemResponseModel>> ByUserAsync(
            string userId)
            => await this.Mapper
                .ProjectTo<EnderecoListagemResponseModel>(this
                    .TodosAsNoTracking()
                    .Where(a => a.UsuarioId == userId))
                .ToListAsync();
    }
}

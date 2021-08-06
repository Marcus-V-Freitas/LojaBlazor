namespace LojaBlazor.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Infrastructure.Services;
    using Models.Enderecos;
    using Services.Enderecos;

    [Authorize]
    public class EnderecosController : ApiController
    {
        private readonly IEnderecosService _enderecoService;
        private readonly ICurrentUserService _usuarioAtualService;

        public EnderecosController(
            IEnderecosService enderecoService,
            ICurrentUserService usuarioService)
        {
            this._enderecoService = enderecoService;
            this._usuarioAtualService = usuarioService;
        }

        [HttpGet]
        public async Task<IEnumerable<EnderecoListagemResponseModel>> Mine()
            => await this._enderecoService.ByUserAsync(this._usuarioAtualService.UsuarioId);

        [HttpPost]
        public async Task<ActionResult> Create(
            EnderecoRequestModel model)
        {
            var usuarioId = this._usuarioAtualService.UsuarioId;
            var id = await this._enderecoService.CreateAsync(model, usuarioId);
            return Created(nameof(this.Create), id);
        }

        [HttpDelete(Id)]
        public async Task<ActionResult> Delete(
            int id)
            => await this._enderecoService
                .DeleteAsync(id, this._usuarioAtualService.UsuarioId)
                .ToActionResult();
    }
}

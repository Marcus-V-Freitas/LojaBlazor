namespace LojaBlazor.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Infrastructure.Services;
    using Models.ListaDesejos;
    using Services.ListaDesejos;

    [Authorize]
    public class ListaDesejosController : ApiController
    {
        private readonly IListaDesejosService _listaDesejosService;
        private readonly ICurrentUserService _usuarioAtualService;

        public ListaDesejosController(
            IListaDesejosService listaDesejosService,
            ICurrentUserService usuarioAtualService)
        {
            this._listaDesejosService = listaDesejosService;
            this._usuarioAtualService = usuarioAtualService;
        }

        [HttpGet]
        public async Task<IEnumerable<ListaDesejosProdutosResponseModel>> Meu()
            => await this._listaDesejosService.ByUserAsync(this._usuarioAtualService.UsuarioId);

        [HttpPost(nameof(AdicionarProduto) + SeparadorCaminho + Id)]
        public async Task<ActionResult> AdicionarProduto(
            int id)
            => await this._listaDesejosService
                .AddProductAsync(id, this._usuarioAtualService.UsuarioId)
                .ToActionResult();

        [HttpDelete(nameof(ExcluirProduto) + SeparadorCaminho + Id)]
        public async Task<ActionResult> ExcluirProduto(
            int id)
            => await this._listaDesejosService
                .RemoveProductAsync(id, this._usuarioAtualService.UsuarioId)
                .ToActionResult();
    }
}

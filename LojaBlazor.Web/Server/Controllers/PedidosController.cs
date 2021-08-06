namespace LojaBlazor.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Services;
    using Services.Pedidos;
    using LojaBlazor.Models.Pedidos;

    [Authorize]
    public class PedidosController : ApiController
    {
        private readonly IPedidosService _pedidosService;
        private readonly ICurrentUserService _usuarioAtualService;

        public PedidosController(
            IPedidosService pedidosService,
            ICurrentUserService usuarioAtualService)
        {
            this._pedidosService = pedidosService;
            this._usuarioAtualService = usuarioAtualService;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidosListagemResponseModel>> Meu()
            => await this._pedidosService.UsuarioPorIdAsync(this._usuarioAtualService.UsuarioId);

        [HttpGet(Id)]
        public async Task<PedidosDetalhesResponseModel> Detalhes(
            string id)
            => await this._pedidosService.DetalhesAsync(id);

        [HttpPost]
        public async Task<ActionResult> Compra(
            PedidosRequestModel model)
        {
            var usuarioId = this._usuarioAtualService.UsuarioId;

            var id = await this._pedidosService.CompraAsync(model, usuarioId);

            return Created(nameof(this.Compra), id);
        }
    }
}

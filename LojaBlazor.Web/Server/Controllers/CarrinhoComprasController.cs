namespace LojaBlazor.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Infrastructure.Services;
    using Models.CarrinhoCompras;
    using Services.ShoppingCarts;

    [Authorize]
    public class CarrinhoComprasController : ApiController
    {
        private readonly ICarrinhoComprasService _carrinhoComprasService;
        private readonly ICurrentUserService _usuarioAtualService;

        public CarrinhoComprasController(
            ICarrinhoComprasService carrinhoComprasService,
            ICurrentUserService usuarioAtualService)
        {
            this._carrinhoComprasService = carrinhoComprasService;
            this._usuarioAtualService = usuarioAtualService;
        }

        [HttpGet]
        public async Task<IEnumerable<CarrinhoComprasProdutoResponseModel>> Meu()
            => await this._carrinhoComprasService.ByUserAsync(this._usuarioAtualService.UsuarioId);

        [HttpGet(nameof(TotalProdutos))]
        public async Task<ActionResult<int>> TotalProdutos()
            => await this._carrinhoComprasService.TotalAsync(this._usuarioAtualService.UsuarioId);

        [HttpPost(nameof(AdicionarProduto))]
        public async Task<ActionResult> AdicionarProduto(
            CarrinhoComprasRequestModel model)
            => await this._carrinhoComprasService
                .AddProductAsync(model, this._usuarioAtualService.UsuarioId)
                .ToActionResult();

        [HttpPut(nameof(EditarProduto))]
        public async Task<ActionResult> EditarProduto(
            CarrinhoComprasRequestModel model)
            => await this._carrinhoComprasService
                .UpdateProductAsync(model, this._usuarioAtualService.UsuarioId)
                .ToActionResult();

        [HttpDelete(nameof(ExcluirProduto) + SeparadorCaminho + Id)]
        public async Task<ActionResult> ExcluirProduto(
            int id)
            => await this._carrinhoComprasService
                .RemoveProductAsync(id, this._usuarioAtualService.UsuarioId)
                .ToActionResult();
    }
}

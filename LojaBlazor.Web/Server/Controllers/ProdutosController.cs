namespace LojaBlazor.Web.Server.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Models.Produtos;
    using Services.Produtos;

    using static Common.Constants;

    [Authorize(Roles = AdministratorRole)]
    public class ProdutosController : ApiController
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
            => this._produtosService = produtosService;

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<ProdutosBuscaResponseModel> Search(
            [FromQuery] ProdutosBuscaRequestModel model)
            => await this._produtosService.SearchAsync(model);

        [HttpGet(Id)]
        [AllowAnonymous]
        public async Task<ProdutosDetalhesResponseModel> Details(
            int id)
            => await this._produtosService.DetailsAsync(id);

        [HttpPost]
        public async Task<ActionResult> Create(
            ProdutosRequestModel model)
        {
            var id = await this._produtosService.CreateAsync(model);

            return Created(nameof(this.Create), id);
        }

        [HttpPut(Id)]
        public async Task<ActionResult> Update(
            int id, ProdutosRequestModel model)
            => await this._produtosService
                .UpdateAsync(id, model)
                .ToActionResult();

        [HttpDelete(Id)]
        public async Task<ActionResult> Delete(
            int id)
            => await this._produtosService
                .DeleteAsync(id)
                .ToActionResult();
    }
}

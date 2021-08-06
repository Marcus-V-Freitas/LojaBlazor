namespace LojaBlazor.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Models.Categorias;
    using Services.Categorias;

    using static Common.Constants;

    [Authorize(Roles = AdministratorRole)]
    public class CategoriasController : ApiController
    {
        private readonly ICategoriasService _categoriasService;

        public CategoriasController(ICategoriasService categoriasService) 
            => this._categoriasService = categoriasService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoriaListagemResponseModel>> All()
            => await this._categoriasService.AllAsync();

        [HttpPost]
        public async Task<ActionResult> Create(
            CategoriasRequestModel model)
        {
            var id = await this._categoriasService.CreateAsync(model);

            return Created(nameof(this.Create), id);
        }

        [HttpPut(Id)]
        public async Task<ActionResult> Update(
            int id, CategoriasRequestModel model)
            => await this._categoriasService
                .UpdateAsync(id, model)
                .ToActionResult();

        [HttpDelete(Id)]
        public async Task<ActionResult> Delete(
            int id)
            => await this._categoriasService
                .DeleteAsync(id)
                .ToActionResult();
    }
}

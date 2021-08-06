namespace LojaBlazor.Web.Server.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Infrastructure.Services;
    using Models.Identity;
    using Services.Identity;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _usuarioAtualService;

        public IdentityController(
            IIdentityService identityService, 
            ICurrentUserService usuarioAtualService)
        {
            this._identityService = identityService;
            this._usuarioAtualService = usuarioAtualService;
        }

        [HttpPost(nameof(Registrar))]
        public async Task<ActionResult> Registrar(
            RegistrarRequestModel model)
            => await this._identityService
                .RegisterAsync(model)
                .ToActionResult();

        [HttpPost(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(
            LoginRequestModel model)
            => await this._identityService
                .LoginAsync(model)
                .ToActionResult();

        [Authorize]
        [HttpPut(nameof(MudarConfiguracoes))]
        public async Task<ActionResult> MudarConfiguracoes(
            TrocarConfiguracoesRequestModel model)
            => await this._identityService
                .ChangeSettingsAsync(model, this._usuarioAtualService.UsuarioId)
                .ToActionResult();

        [Authorize]
        [HttpPut(nameof(MudarSenha))]
        public async Task<ActionResult> MudarSenha(
            TrocarSenhaRequestModel model)
            => await this._identityService
                .ChangePasswordAsync(model, this._usuarioAtualService.UsuarioId)
                .ToActionResult();
    }
}

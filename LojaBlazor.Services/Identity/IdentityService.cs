namespace LojaBlazor.Services.Identity
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Data.Models;
    using Models;
    using Models.Identity;

    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid email or password.";

        private readonly UserManager<Usuario> userManager;
        private readonly IJwtGeneratorService jwtGenerator;

        public IdentityService(
            UserManager<Usuario> userManager,
            IJwtGeneratorService jwtGenerator)
        {
            this.userManager = userManager;
            this.jwtGenerator = jwtGenerator;
        }

        public async Task<Resultado> RegisterAsync(RegistrarRequestModel model)
        {
            var user = new Usuario
            {
                PrimeiroNome = model.PrimeiroNome,
                Sobrenome = model.Sobrenome,
                Email = model.Email,
                UserName = model.Email
            };

            var identityResult = await this.userManager.CreateAsync(user, model.Senha);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Resultado.Success
                : Resultado.Failure(errors);
        }

        public async Task<Result<LoginResponseModel>> LoginAsync(LoginRequestModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Senha);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = await this.jwtGenerator.GenerateJwtAsync(user);

            return new LoginResponseModel { Token = token };
        }

        public async Task<Resultado> ChangeSettingsAsync(
            TrocarConfiguracoesRequestModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            user.PrimeiroNome = model.PrimeiroNome;
            user.Sobrenome = model.Sobrenome;

            var identityResult = await this.userManager.UpdateAsync(user);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Resultado.Success
                : Resultado.Failure(errors);
        }

        public async Task<Resultado> ChangePasswordAsync(
            TrocarSenhaRequestModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                model.Senha,
                model.SenhaNova);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Resultado.Success
                : Resultado.Failure(errors);
        }
    }
}

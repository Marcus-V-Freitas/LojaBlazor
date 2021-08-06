namespace LojaBlazor.Services.Identity
{
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.Identity;

    public interface IIdentityService : IService
    {
        Task<Resultado> RegisterAsync(RegistrarRequestModel model);

        Task<Result<LoginResponseModel>> LoginAsync(LoginRequestModel model);

        Task<Resultado> ChangeSettingsAsync(TrocarConfiguracoesRequestModel model, string userId);

        Task<Resultado> ChangePasswordAsync(TrocarSenhaRequestModel model, string userId);
    }
}

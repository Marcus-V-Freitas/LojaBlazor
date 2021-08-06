namespace LojaBlazor.Web.Client.Infrastructure.Services.Authentication
{
    using System.Threading.Tasks;

    using Models;
    using Models.Identity;

    public interface IAuthService
    {
        Task<Resultado> Registrar(RegistrarRequestModel model);

        Task<Resultado> Login(LoginRequestModel model);

        Task Logout();
    }
}

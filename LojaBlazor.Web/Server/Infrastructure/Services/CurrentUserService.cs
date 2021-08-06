namespace LojaBlazor.Web.Server.Infrastructure.Services
{
    using System;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var usuario = httpContextAccessor.HttpContext?.User;

            if (usuario == null)
            {
                throw new InvalidOperationException("Esta solicitação não possui um usuário autenticado.");
            }

            this.UsuarioId = usuario.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UsuarioId { get; }
    }
}

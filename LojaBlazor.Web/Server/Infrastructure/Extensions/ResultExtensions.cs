namespace LojaBlazor.Web.Server.Infrastructure.Extensions
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Models;

    public static class ResultExtensions
    {
        public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<TData> resultTask)
        {
            var resultado = await resultTask;

            if (resultado == null)
            {
                return new NotFoundResult();
            }

            return resultado;
        }

        public static async Task<ActionResult> ToActionResult(this Task<Resultado> resultTask)
        {
            var resultado = await resultTask;

            if (!resultado.Sucesso)
            {
                return new BadRequestObjectResult(resultado.Erros);
            }

            return new OkResult();
        }

        public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<Result<TData>> resultTask)
        {
            var result = await resultTask;

            if (!result.Sucesso)
            {
                return new BadRequestObjectResult(result.Erros);
            }

            return result.Data;
        }
    }
}

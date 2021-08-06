namespace LojaBlazor.Web.Server.Middleware
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class ValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ValidationExceptionHandlerMiddleware(RequestDelegate next)
            => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var codigo = HttpStatusCode.InternalServerError;

            var resultado = string.Empty;

            if (exception is NullReferenceException)
            {
                codigo = HttpStatusCode.BadRequest;
                resultado = SerializeObject(new[] { "Requisição Inválida." });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)codigo;

            if (string.IsNullOrEmpty(resultado))
            {
                var erro = exception.Message;
                resultado = SerializeObject(new[] { erro });
            }

            return context.Response.WriteAsync(resultado);
        }

        private static string SerializeObject(object obj)
            => JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(true, true)
                }
            });
    }

    public static class ValidationExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<ValidationExceptionHandlerMiddleware>();
    }
}

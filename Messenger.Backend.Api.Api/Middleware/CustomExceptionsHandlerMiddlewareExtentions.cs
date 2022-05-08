using Microsoft.AspNetCore.Builder;

namespace Messenger.Backend.Api.Api.Middleware
{
    public static class CustomExceptionsHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(
           this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}

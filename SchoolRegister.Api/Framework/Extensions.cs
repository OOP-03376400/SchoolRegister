using Microsoft.AspNetCore.Builder;

namespace SchoolRegister.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}
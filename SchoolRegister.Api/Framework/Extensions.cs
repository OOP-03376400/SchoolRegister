using Microsoft.AspNetCore.Builder;

namespace SchoolRegister.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMyExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}
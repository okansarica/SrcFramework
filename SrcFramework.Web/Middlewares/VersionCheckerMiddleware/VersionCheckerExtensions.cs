using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace SrcFramework.Web.Middlewares.VersionCheckerMiddleware
{
    public static class VersionCheckerExtensions
    {
        public static IApplicationBuilder UseVersionChecker(this IApplicationBuilder app, VersionCheckerOptions options)
        {
            return app.UseMiddleware<VersionChecker>(Options.Create(options));
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SrcFramework.Web.Middlewares.VersionCheckerMiddleware
{
    public class VersionChecker
    {
        private readonly RequestDelegate _nextMiddleWare;
        private readonly VersionCheckerOptions _options;

        public VersionChecker(RequestDelegate next, IOptions<VersionCheckerOptions> options)
        {
            _nextMiddleWare = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            //var request = context.Request;
            var version = Convert.ToString(context.Request.Headers["version"]);
            var result = true;

            if (string.IsNullOrWhiteSpace(version))
            {
                result = false;
            }
            else
            {
                if (!_options.AcceptedVersions.Contains(version))
                {
                    result = false;
                }
            }

            if (result)
            {
                await _nextMiddleWare(context);
            }
            else
            {
                //TODO
//                context.Response.ContentType = "application/json";
//                await context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseViewModel
//                {
//                    IsSuccessfull = false,
//                    Message = _options.ErrorMessage,
//                    IsBusinessException = false
//                }, new JsonSerializerSettings
//                {
//                    ContractResolver = new CamelCasePropertyNamesContractResolver()
//                }));
            }
        }
    }
}

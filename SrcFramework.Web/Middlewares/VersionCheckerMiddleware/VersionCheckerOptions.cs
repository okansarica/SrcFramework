using System.Collections.Generic;

namespace SrcFramework.Web.Middlewares.VersionCheckerMiddleware
{
    public class VersionCheckerOptions
    {
        public List<string> AcceptedVersions { get; set; }
        public string ErrorMessage { get; set; }
    }
}

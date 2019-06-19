namespace SrcFramework.Web.Middlewares.VersionCheckerMiddleware
{
    internal class BaseViewModel
    {
        public bool IsSuccessfull { get; set; }
        public object Message { get; set; }
        public object IsBusinessException { get; set; }
    }
}
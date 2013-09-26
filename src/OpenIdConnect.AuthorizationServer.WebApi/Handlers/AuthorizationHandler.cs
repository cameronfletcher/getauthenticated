namespace OpenIdConnect.AuthorizationServer.WebApi.Handlers
{
    using System.Net;
    using OpenIdConnect.AuthorizationServer.WebApi.Resources;
    using ServiceStack.Common.Web;
    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface.Cors;

    public sealed class AuthorizationHandler : IService
    {
        [EnableCors(allowedMethods: "GET,OPTIONS", allowedHeaders: "accept, origin, authorization, content-type")]
        public object Get(AuthorizationRequest request)
        {
            return new HttpResult
            {
                StatusCode = HttpStatusCode.Redirect,
                Headers =
                {
                    { "Cache-Control", "no-store" },
                    { "Pragma", "no-cache" },
                },
            };
        }

        [EnableCors(allowedMethods: "GET,OPTIONS", allowedHeaders: "accept, origin, authorization, content-type")]
        public void Options(AuthorizationRequest request)
        {
        }
    }
}

namespace OpenIdConnect.ResourceServer.WebApi
{
    using System.Collections.Generic;
    using System.Net;
    using ServiceStack.Common.Web;
    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface;
    using ServiceStack.WebHost.Endpoints.Extensions;

    public sealed class AuthenticateAttribute : RequestFilterAttribute
    {
        public string RequireClaim { get; set; }

        // RFC (Cameron): OAuth 2.0 Bearer Token Usage (rfc6750)
        // LINK (Cameron): http://tools.ietf.org/html/rfc6750
        public override void Execute(IHttpRequest request, IHttpResponse response, object requestDto)
        {
            var authorizationHeader = request.Headers["Authorization"];
            if (authorizationHeader == null || !authorizationHeader.ToLowerInvariant().StartsWith("bearer "))
            {
                // check authorization header contains Bearer "accessToken"
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.AddHeader(HttpHeaders.WwwAuthenticate, "Bearer");
                response.EndServiceStackRequest();

                return;
            }

            var accessToken = authorizationHeader.Substring(7); /* or request.QueryString["access_token"]; */
            // query OpenIdConnect.AuthorizationServer.WebApi (UserInfo Endpoint)

            // LINK (Cameron): http://nat.sakimura.org/2012/01/26/scopes-and-claims-in-openid-connect/
            // custom claims/scopes are supposed to be unique eg. URIs
            // read claims out and place into request, somehow...

            var claims = new Dictionary<string, string>
            {
                { "sub", "cameronfletcher" },
                { "http://getnotified.com/user/admin", "true" }
            };

            //container.Register(c => new MyType()).ReusedWithin(ReuseScope.None);
            return;

            // unauthorized
            response.StatusCode = (int)HttpStatusCode.Unauthorized;
            response.AddHeader(HttpHeaders.WwwAuthenticate, "Bearer");
            response.EndServiceStackRequest();
        }
    }
}

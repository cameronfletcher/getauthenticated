namespace OpenIdConnect.AuthorizationServer.WebApi.Handlers
{
    using System;
    using System.IO;
    using System.Text;
    using OpenIdConnect.AuthorizationServer.WebApi.Resources;
    using ServiceStack.Common.Web;
    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface.Cors;

    // RFC (Cameron): [Handler for] 2.1.6.1. Client Sends Code (ref. openid-connect-basic-1_0)
    // TODO (Cameron): Must use TLS (HTTPS).
    public sealed class AuthenticationHandler : IService
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationHandler(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [EnableCors(allowedMethods: "POST,OPTIONS", allowedHeaders: "authorization, content-type")]
        public object Post(AuthenticationRequest request)
        {
            // TODO (Cameron): Require that Content-Type is application/x-www-form-urlencoded
            // TODO (Cameron): Require that request.GrantType == "authorization_code"
            // NOTE (Cameron): Here we federate to Google...
            this.authenticationService.Authenticate(request.Code, request.RedirectUri);

            var accessToken = CreateAccessToken();
            var idToken = CreateIdToken();

            // save access token in repository along with user rights/JWT?

            return new HttpResult(
                new AuthenticationResponse
                {
                    AccessToken = accessToken,
                    TokenType = "Bearer",
                    IdToken = idToken,
                })
            {
                Headers =
                {
                    { "Cache-Control", "no-store" },
                    { "Pragma", "no-cache" },
                },
            };
        }

        [EnableCors(allowedMethods: "POST,OPTIONS", allowedHeaders: "authorization, content-type")]
        public void Options(AuthenticationRequest request)
        {
        }

        private static string CreateAccessToken()
        {
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(Path.GetRandomFileName()));
        }

        private static string CreateIdToken()
        {
            // LINK (Cameron): http://openid.net/specs/openid-connect-basic-1_0.html#rfc.section.2.2
            return "eyJ0 ... NiJ9.eyJ1c ... I6IjIifX0.DeWt4Qu ... ZXso";
        }
    }
}
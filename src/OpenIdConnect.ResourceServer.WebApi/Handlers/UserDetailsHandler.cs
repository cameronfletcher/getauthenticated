namespace OpenIdConnect.ResourceServer.WebApi.Handlers
{
    using OpenIdConnect.ResourceServer.WebApi.Resources;
    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface.Cors;

    public sealed class UserDetailsHandler : IService
    {
        [Authenticate(RequireClaim = "http://getnotified.net/2013/07/identity/claims/userdetails")]
        [EnableCors(allowedOrigins: "http://localhost:49856", allowedMethods: "GET,OPTIONS", allowedHeaders: "authorization, content-type")]
        public object Get(UserDetailsRequest request)
        {
            // get access token from header: Authorization: Bearer {accessToken}
            // verify that access token is valid with authorization server
            // LINK (Cameron): https://developers.google.com/accounts/docs/OAuth2Login
            // NOTE (Cameron): The intention is to be authenticated by this point.
            return new UserDetailsResponse
            {
                Username = "cameronfletcher",
                EmailAddress = "cameron.fletcher@cameronfletcher.com"
            };
        }

        [EnableCors(allowedOrigins: "http://localhost:49856", allowedMethods: "GET,OPTIONS", allowedHeaders: "authorization, content-type")]
        public void Options(UserDetailsRequest request)
        {
        }
    }
}

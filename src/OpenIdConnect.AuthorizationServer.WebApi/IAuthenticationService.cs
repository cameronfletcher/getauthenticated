namespace OpenIdConnect.AuthorizationServer.WebApi
{
    public interface IAuthenticationService
    {
        void Authenticate(string grantType, string code, string redirectUri);
    }
}

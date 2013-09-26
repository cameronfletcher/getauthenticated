namespace OpenIdConnect.AuthorizationServer.WebApi
{
    public interface IAuthenticationService
    {
        void Authenticate(string code, string redirectUri);
    }
}

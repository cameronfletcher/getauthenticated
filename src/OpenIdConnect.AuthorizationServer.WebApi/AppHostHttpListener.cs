namespace OpenIdConnect.AuthorizationServer.WebApi
{
    using Funq;
    using OpenIdConnect.AuthorizationServer.WebApi.Handlers;
    using ServiceStack.WebHost.Endpoints;

    public sealed class AppHostHttpListener : AppHostHttpListenerBase
    {
        public AppHostHttpListener()
            : base("OpenID Connect Web API (Authorization Server)", typeof(AuthenticationHandler).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            container.Register<IAuthenticationService>(
                new GoogleAuthenticationService("519195177062.apps.googleusercontent.com", "zojzmj3X1FeiCUOWW-kYjRuV"));
        }
    }
}

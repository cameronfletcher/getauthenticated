namespace OpenIdConnect.ResourceServer.WebApi
{
    using Funq;
    using OpenIdConnect.ResourceServer.WebApi.Handlers;
    using ServiceStack.WebHost.Endpoints;

    public sealed class AppHostHttpListener : AppHostHttpListenerBase
    {
        public AppHostHttpListener()
            : base("OpenID Connect Web API (Resource Server)", typeof(UserDetailsHandler).Assembly)
        {
        }

        public override void Configure(Container container)
        {
        }
    }
}

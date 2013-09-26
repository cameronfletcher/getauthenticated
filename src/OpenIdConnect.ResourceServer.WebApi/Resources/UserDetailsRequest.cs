namespace OpenIdConnect.ResourceServer.WebApi.Resources
{
    using System.Runtime.Serialization;
    using ServiceStack.ServiceHost;

    [DataContract, Route("/userdetails", "GET,OPTIONS")]
    public class UserDetailsRequest : IReturn<UserDetailsResponse>
    {
    }
}

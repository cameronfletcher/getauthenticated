namespace OpenIdConnect.AuthorizationServer.WebApi.Resources
{
    using System.Runtime.Serialization;
    using ServiceStack.ServiceHost;

    [DataContract, Route("/authenticate", "POST,OPTIONS")]
    public class AuthenticationRequest : IReturn<AuthenticationResponse>
    {
        [DataMember(Name = "grant_type")]
        public string GrantType { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "redirect_uri")]
        public string RedirectUri { get; set; }
    }
}
    
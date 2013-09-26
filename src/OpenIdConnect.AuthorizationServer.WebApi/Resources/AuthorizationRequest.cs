namespace OpenIdConnect.AuthorizationServer.WebApi.Resources
{
    using System.Runtime.Serialization;
    using ServiceStack.ServiceHost;

    [DataContract, Route("/authorise", "GET,OPTIONS")]
    public class AuthorizationRequest : IReturnVoid
    {
        [DataMember(Name = "response_type")]
        public string ResponseType { get; set; }

        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        [DataMember(Name = "scope")]
        public string Scope { get; set; }

        [DataMember(Name = "redirect_uri")]
        public string RedirectUri { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }
    }
}
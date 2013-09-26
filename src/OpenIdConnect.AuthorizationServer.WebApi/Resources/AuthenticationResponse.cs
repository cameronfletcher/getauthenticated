namespace OpenIdConnect.AuthorizationServer.WebApi.Resources
{
    using System.Runtime.Serialization;

    // LINK (Cameron): http://openid.net/specs/openid-connect-basic-1_0.html#rfc.section.2.1.6.2
    [DataContract]
    public class AuthenticationResponse
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }

        [DataMember(Name = "id_token")]
        public string IdToken { get; set; }

        [DataMember(Name = "expires_in", EmitDefaultValue = false)]
        public int? ExpiresIn { get; set; }

        [DataMember(Name = "refresh_token", EmitDefaultValue = false)]
        public string RefreshToken { get; set; }
    }
}

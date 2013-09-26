namespace OpenIdConnect.ResourceServer.WebApi.Resources
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserDetailsResponse
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "emailAddress")]
        public string EmailAddress { get; set; }
    }
}

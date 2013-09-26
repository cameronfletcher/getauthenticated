namespace OpenIdConnect.AuthorizationServer.WebApi
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;

    public sealed class GoogleAuthenticationService : IAuthenticationService
    {
        private static readonly string FormData = "code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type={4}";

        private readonly string clientId;
        private readonly string clientSecret;

        public GoogleAuthenticationService(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        public void Authenticate(string code, string redirectUri)
        {
            var formData = string.Format(CultureInfo.InvariantCulture, FormData, code, clientId, clientSecret, redirectUri, "authorization_code");
            var uri = new Uri("https://accounts.google.com/o/oauth2/token");
            
            // NOTE (Cameron): The response contains the token from Google. It is from here we have to pull the identity.
            var response = HttpPost(uri, formData);
        }

        private static string HttpPost(Uri uri, string parameters)
        {
            var bytes = Encoding.ASCII.GetBytes(parameters);
            var request = WebRequest.Create(uri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = bytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length); //Push it out there
            }

            var response = request.GetResponse();
            if (response == null)
            {
                return null;
            }

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd().Trim();
            }
        }
    }
}
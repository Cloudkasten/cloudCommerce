using cloudCommerce.Core.Configuration;

namespace cloudCommerce.FacebookAuth
{
    public class FacebookExternalAuthSettings : ISettings
    {
        public string ClientKeyIdentifier { get; set; }
        public string ClientSecret { get; set; }
    }
}

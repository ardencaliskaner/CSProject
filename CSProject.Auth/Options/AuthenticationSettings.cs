namespace CSProject.Auth.Options
{
    public class AuthenticationSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
    }
}
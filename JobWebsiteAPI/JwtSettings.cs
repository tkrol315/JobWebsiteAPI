namespace JobWebsiteAPI
{
    public class JwtSettings
    {
        public string JwtIssuer { get; set;}
        public string JwtAudience { get; set; }
        public int JwtExpireMins { get; set;}
        public string JwtKey { get; set;}
    }
}
